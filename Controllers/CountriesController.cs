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
    public class CountriesController : Controller
    {
        private EducareContext db = new EducareContext();

        // GET: Countries
        public ActionResult Index()
        {
            return View();
        }

        // GET: Countries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // GET: Countries/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    country.Status = true;
                    db.Countries.Add(country);
                    db.SaveChanges();
                    TempData["Msg"] = "1";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = MyFunctions.HandleMyError(ex);
                    return View(country);
                }
               
            }

            return View(country);
        }

        // GET: Countries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Status")] Country country)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(country).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["Msg"] = "2";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = MyFunctions.HandleMyError(ex);
                    return View(country);
                }
                
            }
            return View(country);
        }

        // GET: Countries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Country country = db.Countries.Find(id);
            db.Countries.Remove(country);
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
