using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace EduCare.Models
{
    public class MyFunctions
    {
        public static string HandleMyError(Exception ex)
        {
            string res = string.Empty;
            if (ex.InnerException.ToString().Contains("Violation of UNIQUE KEY"))
            {
                res = "Can not insert duplicate data.";
            }
            else
            {
                res = "Oops! Network Error. Try again later.";
            }
            return res;
        }

        public static Boolean AuthenticateUser
        {
            get
            {
                string uid = Cookies.GetUsersDetails.UserName;
                string pwd = Cookies.GetUsersDetails.Password;
                int Id = Cookies.GetUsersDetails.Id;
                string res = AllProcs.CheckUser(uid, pwd);
                if (Convert.ToInt32(res) == Id)
                {
                    return true;
                }
                return false;
            }
        }

        public static int GetUid
        {
            get
            {
                try
                {
                    return Cookies.GetUsersDetails.Id;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public static string GetCurrentTime()
        {
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            StringBuilder result = new StringBuilder();
            int Hour = currentTime.Hours;
            int minute = currentTime.Minutes;
            string min = minute.ToString();
            if (minute < 9)
            {
                min = "0" + minute.ToString();
            }
            if (Hour > 12)
            {
                Hour -= 12;
                if (Hour > 9)
                    result.Append(Hour.ToString() + ":" + min + " PM");
                else
                    result.Append("0" + Hour.ToString() + ":" + min + " PM");
            }
            else
            {
                if (Hour > 9)
                    result.Append(Hour.ToString() + ":" + min + " AM");
                else
                    result.Append("0" + Hour.ToString() + ":" + min + " AM");
            }
            return result.ToString();
        }
    }
}