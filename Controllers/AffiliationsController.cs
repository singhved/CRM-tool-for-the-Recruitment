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
    public class AffiliationsController : Controller
    {
        private EducareContext db = new EducareContext();

        // GET: Affiliations
        public ActionResult Index()
        {
            return View();
        }

        // GET: Affiliations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Affiliation affiliation = db.Affiliations.Find(id);
            if (affiliation == null)
            {
                return HttpNotFound();
            }
            return View(affiliation);
        }

        // GET: Affiliations/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Affiliation affiliation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    affiliation.Status = true;
                    db.Affiliations.Add(affiliation);
                    db.SaveChanges();
                    TempData["Msg"] = "1";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = MyFunctions.HandleMyError(ex);
                    return View(affiliation);
                }
                
            }
            return View(affiliation);

        }

        // GET: Affiliations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Affiliation affiliation = db.Affiliations.Find(id);
            if (affiliation == null)
            {
                return HttpNotFound();
            }
            return View(affiliation);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Affiliation affiliation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(affiliation).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["Msg"] = "2";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = MyFunctions.HandleMyError(ex);
                    return View(affiliation);
                }
            }
            return View(affiliation);
        }

        // GET: Affiliations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Affiliation affiliation = db.Affiliations.Find(id);
            if (affiliation == null)
            {
                return HttpNotFound();
            }
            return View(affiliation);
        }

        // POST: Affiliations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Affiliation affiliation = db.Affiliations.Find(id);
            db.Affiliations.Remove(affiliation);
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
