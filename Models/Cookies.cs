using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using EduCare.Models;

namespace EduCare.Models
{
    public class Cookies
    {
        public static void SaveCookies(int? Id)
        {
            EducareContext db = new EducareContext();
            var users = db.Users.Where(x => x.Id == Id).FirstOrDefault();
            HttpContext.Current.Response.Cookies["EMPDS"].Value = EduSecurity.Encrypt(JsonConvert.SerializeObject(users));
        }
        public static void Logout()
        {
            HttpContext.Current.Response.Cookies["EMPDS"].Expires = DateTime.Now.Date.AddDays(-1);
        }

        public static Users GetUsersDetails
        {
            get
            {
                Users users;
                try
                {
                    var data = HttpContext.Current.Request.Cookies["EMPDS"].Value;
                    if (data != null)
                    {
                        users = JsonConvert.DeserializeObject<Users>(EduSecurity.Decrypt(data));
                        return users;
                    }
                }
                catch (Exception) { }
                users = new Users();
                return users;
            }
        }
    }
}