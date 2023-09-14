using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduCare.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ForgotPwd()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
    }
}