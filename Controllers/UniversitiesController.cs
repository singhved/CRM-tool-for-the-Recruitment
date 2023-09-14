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
    public class UniversitiesController : Controller
    {
        private EducareContext db = new EducareContext();

        // GET: Universities
        public ActionResult Index()
        {
            return View();
        }

        // GET: Universities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            University university = db.Universities.Find(id);
            if (university == null)
            {
                return HttpNotFound();
            }
            return View(university);
        }

        // GET: Universities/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( University university)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    university.Status = true;
                    db.Universities.Add(university);
                    db.SaveChanges();
                    TempData["Msg"] = "1";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = MyFunctions.HandleMyError(ex);
                    return View(university);
                }
                
            }

            return View(university);
        }

        // GET: Universities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            University university = db.Universities.Find(id);
            if (university == null)
            {
                return HttpNotFound();
            }
            return View(university);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(University university)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(university).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["Msg"] = "2";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = MyFunctions.HandleMyError(ex);
                    return View(university);
                }
                
            }
            return View(university);
        }

        // GET: Universities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            University university = db.Universities.Find(id);
            if (university == null)
            {
                return HttpNotFound();
            }
            return View(university);
        }

        // POST: Universities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            University university = db.Universities.Find(id);
            db.Universities.Remove(university);
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
