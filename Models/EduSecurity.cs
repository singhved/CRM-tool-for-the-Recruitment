using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace EduCare.Models
{
    public class EduSecurity
    {
        private static string EncryptionKey = "cdg46g@^@@csdc";

        public static string Encrypt(string PlainText)
        {
            byte[] CB = Encoding.Unicode.GetBytes(PlainText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes Rf = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = Rf.GetBytes(32);
                encryptor.IV = Rf.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(CB, 0, CB.Length);
                        cs.Close();
                    }
                    PlainText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return PlainText;
        }

        public static string Decrypt(string CipherText)
        {
            CipherText = CipherText.Replace(" ", "+");
            byte[] CB = Convert.FromBase64String(CipherText);
            using (Aes decryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                decryptor.Key = pdb.GetBytes(32);
                decryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(CB, 0, CB.Length);
                        cs.Close();
                    }
                    CipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }

            return CipherText;
        }
    }
}