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
    public class CandidateStatusController : Controller
    {
        private EducareContext db = new EducareContext();

        // GET: CandidateStatus
        public ActionResult Index()
        {
            return View(db.CandidateStatus.ToList());
        }

        // GET: CandidateStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateStatusView candidateStatus = db.CandidateStatusView.Find(id);
            if (candidateStatus == null)
            {
                return HttpNotFound();
            }
            return View(candidateStatus);
        }

        // GET: CandidateStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( CandidateStatus candidateStatus)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    candidateStatus.status = 0;
                    db.CandidateStatus.Add(candidateStatus);
                    db.SaveChanges();
                    TempData["Msg"] = "1";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = MyFunctions.HandleMyError(ex);
                    return View(candidateStatus);
                }
                
            }

            return View(candidateStatus);
        }

        // GET: CandidateStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateStatus candidateStatus = db.CandidateStatus.Find(id);
            if (candidateStatus == null)
            {
                return HttpNotFound();
            }
            return View(candidateStatus);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CandidateStatus candidateStatus)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(candidateStatus).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["Msg"] = "2";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = MyFunctions.HandleMyError(ex);
                    return View(candidateStatus);
                }
                
            }
            return View(candidateStatus);
        }

        // GET: CandidateStatus/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CandidateStatus candidateStatus = db.CandidateStatus.Find(id);
        //    if (candidateStatus == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(candidateStatus);
        //}

        //// POST: CandidateStatus/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    CandidateStatus candidateStatus = db.CandidateStatus.Find(id);
        //    db.CandidateStatus.Remove(candidateStatus);
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
