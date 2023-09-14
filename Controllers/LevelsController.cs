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
    public class LevelsController : Controller
    {
        private EducareContext db = new EducareContext();

        // GET: Levels
        public ActionResult Index()
        {
            return View();
        }

        // GET: Levels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Level level = db.Levels.Find(id);
            if (level == null)
            {
                return HttpNotFound();
            }
            return View(level);
        }

        // GET: Levels/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Level level)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    level.Status = true;
                    db.Levels.Add(level);
                    db.SaveChanges();
                    TempData["Msg"] = "1";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = MyFunctions.HandleMyError(ex);
                    return View(level);
                }

            }
            return View(level);
        }

        // GET: Levels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Level level = db.Levels.Find(id);
            if (level == null)
            {
                return HttpNotFound();
            }
            return View(level);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Level level)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(level).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["Msg"] = "2";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = MyFunctions.HandleMyError(ex);
                    return View(level);
                }
                
            }
            return View(level);
        }

        // GET: Levels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Level level = db.Levels.Find(id);
            if (level == null)
            {
                return HttpNotFound();
            }
            return View(level);
        }

        // POST: Levels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Level level = db.Levels.Find(id);
            db.Levels.Remove(level);
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
