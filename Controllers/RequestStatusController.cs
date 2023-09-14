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
    public class RequestStatusController : Controller
    {
        private EducareContext db = new EducareContext();

        // GET: RequestStatus
        public ActionResult Index()
        {
            return View(db.RequestStatus.ToList());
        }

        // GET: RequestStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestStatusView requestStatus = db.RequestStatusView.Find(id);
            if (requestStatus == null)
            {
                return HttpNotFound();
            }
            return View(requestStatus);
        }

        // GET: RequestStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RequestStatus requestStatus)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    requestStatus.status = 1;
                    db.RequestStatus.Add(requestStatus);
                    db.SaveChanges();
                    TempData["Msg"] = "1";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = MyFunctions.HandleMyError(ex);
                    return View(requestStatus);
                }
                
            }

            return View(requestStatus);
        }

        // GET: RequestStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestStatus requestStatus = db.RequestStatus.Find(id);
            if (requestStatus == null)
            {
                return HttpNotFound();
            }
            return View(requestStatus);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RequestStatus requestStatus)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(requestStatus).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["Msg"] = "2";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = MyFunctions.HandleMyError(ex);
                    return View(requestStatus);
                }
                
            }
            return View(requestStatus);
        }

        // GET: RequestStatus/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    RequestStatus requestStatus = db.RequestStatus.Find(id);
        //    if (requestStatus == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(requestStatus);
        //}

        //// POST: RequestStatus/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    RequestStatus requestStatus = db.RequestStatus.Find(id);
        //    db.RequestStatus.Remove(requestStatus);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
