using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;


namespace EduCare.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult TermsnConditions()
        //{
        //    return View();
        //}
        //public ActionResult Email(string ToMail, string Sub, string Body, string CcMail = null, HttpPostedFileBase file = null)
        //{
        //    var message = new MailMessage();
        //    message.To.Add(ToMail);

        //    if (!string.IsNullOrEmpty(CcMail))
        //        message.CC.Add(CcMail);

        //    if (file != null)
        //    {
        //        string filename = Path.GetFileName(file.FileName);

        //        message.Attachments.Add(new Attachment(file.InputStream, "filename.pdf"));
        //        //message.Attachments.Add(new Attachment(file.InputStream, filename));
        //    }

        //    message.From = new MailAddress("");
        //    message.Subject = Sub;
        //    //message.Body = Body;
        //    Body += "Email: " + Body + "<br/>";
        //    message.IsBodyHtml = true;

        //    using (var smtp = new SmtpClient())
        //    {
        //        var credential = new NetworkCredential
        //        {
        //            UserName = "",
        //            Password = ""
        //        };
        //        smtp.Credentials = credential;
        //        smtp.Host = "smtp-mail.outlook.com";
        //        smtp.Port = 587;
        //        smtp.EnableSsl = true;
        //        smtp.Send(message);
        //    }
            
        //    return View();
        //}
    }
}