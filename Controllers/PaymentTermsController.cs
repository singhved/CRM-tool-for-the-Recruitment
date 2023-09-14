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
    public class PaymentTermsController : Controller
    {
        private EducareContext db = new EducareContext();

        // GET: PaymentTerms
        public ActionResult Index()
        {
            return View(db.PaymentTerms.ToList());
        }

        // GET: PaymentTerms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentTerms paymentTerms = db.PaymentTerms.Find(id);
            if (paymentTerms == null)
            {
                return HttpNotFound();
            }
            return View(paymentTerms);
        }

        // GET: PaymentTerms/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PaymentTerms paymentTerms)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    paymentTerms.Status = true;
                    db.PaymentTerms.Add(paymentTerms);
                    db.SaveChanges();
                    TempData["Msg"] = "1";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = MyFunctions.HandleMyError(ex);
                    return View(paymentTerms);
                }
                
            }

            return View(paymentTerms);
        }

        // GET: PaymentTerms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentTerms paymentTerms = db.PaymentTerms.Find(id);
            if (paymentTerms == null)
            {
                return HttpNotFound();
            }
            return View(paymentTerms);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PaymentTerms paymentTerms)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(paymentTerms).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["Msg"] = "2";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = MyFunctions.HandleMyError(ex);
                    return View(paymentTerms);
                }
                
            }
            return View(paymentTerms);
        }

        // GET: PaymentTerms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentTerms paymentTerms = db.PaymentTerms.Find(id);
            if (paymentTerms == null)
            {
                return HttpNotFound();
            }
            return View(paymentTerms);
        }

        // POST: PaymentTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaymentTerms paymentTerms = db.PaymentTerms.Find(id);
            db.PaymentTerms.Remove(paymentTerms);
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
