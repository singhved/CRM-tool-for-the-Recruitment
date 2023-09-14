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
    public class DegreesController : Controller
    {
        private EducareContext db = new EducareContext();

        // GET: Degrees
        public ActionResult Index()
        {
            return View();
        }

        // GET: Degrees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Degree degree = db.Degrees.Find(id);
            if (degree == null)
            {
                return HttpNotFound();
            }
            return View(degree);
        }

        // GET: Degrees/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Degree degree)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    degree.Status = true;
                    db.Degrees.Add(degree);
                    db.SaveChanges();
                    TempData["Msg"] = "1";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = MyFunctions.HandleMyError(ex);
                    return View(degree);
                }
                
            }

            return View(degree);
        }

        // GET: Degrees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Degree degree = db.Degrees.Find(id);
            if (degree == null)
            {
                return HttpNotFound();
            }
            return View(degree);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Degree degree)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(degree).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["Msg"] = "2";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = MyFunctions.HandleMyError(ex);
                    return View(degree);
                }
                
            }
            return View(degree);
        }

        // GET: Degrees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Degree degree = db.Degrees.Find(id);
            if (degree == null)
            {
                return HttpNotFound();
            }
            return View(degree);
        }

        // POST: Degrees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Degree degree = db.Degrees.Find(id);
            db.Degrees.Remove(degree);
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
