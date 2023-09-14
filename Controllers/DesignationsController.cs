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
    public class DesignationsController : Controller
    {
        private EducareContext db = new EducareContext();

        // GET: Designations
        public ActionResult Index()
        {
            return View();
        }

        // GET: Designations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designation designation = db.Designations.Find(id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }

        // GET: Designations/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Designation designation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    designation.Status = true;
                    db.Designations.Add(designation);
                    db.SaveChanges();
                    TempData["Msg"] = "1";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = MyFunctions.HandleMyError(ex);
                    return View(designation);
                }
            }
            return View(designation);
        }

        // GET: Designations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designation designation = db.Designations.Find(id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Designation designation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(designation).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["Msg"] = "2";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = MyFunctions.HandleMyError(ex);
                    return View(designation);
                }
                
            }
            return View(designation);
        }

        // GET: Designations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designation designation = db.Designations.Find(id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }

        // POST: Designations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Designation designation = db.Designations.Find(id);
            db.Designations.Remove(designation);
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
