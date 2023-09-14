using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EduCare.Models;

namespace EduCare.Controllers
{
    public class SubjectsController : Controller
    {
        private EducareContext db = new EducareContext();

        // GET: Subjects
        public ActionResult Index()
        {
            return View();
        }

        // GET: Subjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // GET: Subjects/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Subject subject)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    subject.Status = true;
                    db.Subjects.Add(subject);
                    db.SaveChanges();
                    TempData["Msg"] = "1";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = MyFunctions.HandleMyError(ex);
                    return View(subject);
                }
                
            }

            return View(subject);
        }

        // GET: Subjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Subject subject)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(subject).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["Msg"] = "2";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = MyFunctions.HandleMyError(ex);
                    return View(subject);
                }
                
            }
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subject subject = db.Subjects.Find(id);
            db.Subjects.Remove(subject);
            db.SaveChanges();
            TempData["Msg"] = "3";
            return RedirectToAction("Index");
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
