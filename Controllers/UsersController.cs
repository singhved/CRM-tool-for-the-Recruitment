using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EduCare.Models;

namespace EduCare.Controllers
{
    public class UsersController : Controller
    {
        private EducareContext db = new EducareContext();

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersView users = db.UsersViews.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Users users, HttpPostedFileBase ProfilePicture)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (ProfilePicture != null && ProfilePicture.ContentLength > 0)
                    {
                        string ext = Path.GetExtension(ProfilePicture.FileName);
                        string fileName = "MyFile_" + DateTime.Now.Ticks + ext;
                        string filePath = Path.Combine(Server.MapPath("~/UploadedFiles/"), fileName);
                        ProfilePicture.SaveAs(filePath);
                        users.ProfilePicture = fileName;
                    }
                    users.Status = true;
                    db.Users.Add(users);
                    db.SaveChanges();
                    TempData["Msg"] = "1";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = MyFunctions.HandleMyError(ex);
                    return View(users);
                }

            }

            return View(users);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Users users)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(users).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["Msg"] = "2";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = MyFunctions.HandleMyError(ex);
                    return View(users);
                }

            }
            return View(users);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersView users = db.UsersViews.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Users users = db.Users.Find(id);
            db.Users.Remove(users);
            db.SaveChanges();
            TempData["Msg"] = "3";
            return RedirectToAction("Index");
        }

        public string Authenticate(string UserName, string Password)
        {
            string res = AllProcs.CheckUser(UserName, Password);
            if (Convert.ToInt32(res) > 0)
                Cookies.SaveCookies(Convert.ToInt32(res));
            return res;
        }
        public ActionResult Logout()
        {
            Cookies.Logout();
            return RedirectToAction("Index", "LogIn");
        }
        public PartialViewResult ChangePassword()
        {
            return PartialView();
        }
        public string ChangeUserPassword(string Password, string NewPassword)
        {
            return AllProcs.ChangePassword(Password, NewPassword);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
