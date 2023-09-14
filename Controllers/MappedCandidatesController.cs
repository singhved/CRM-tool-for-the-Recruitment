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
    public class MappedCandidatesController : Controller
    {
        private EducareContext db = new EducareContext();

        // GET: MappedCandidates
        public ActionResult Index()
        {
            return View(db.MappedCandidates.ToList());
        }

        // GET: MappedCandidates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MappedCandidates mappedCandidates = db.MappedCandidates.Find(id);
            if (mappedCandidates == null)
            {
                return HttpNotFound();
            }
            return View(mappedCandidates);
        }

        // GET: MappedCandidates/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: MappedCandidates/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,RequestId,CandidateId,MappedBy,Status,Cdate,ApprovalBy,ApprovalDate,VideoLinkSent,Video,VidUploadDate,VidStatus,VidApprovalBy,VidSubmissions,SentToClient,ApprovedByClient,ClientApprovalDate")] MappedCandidates mappedCandidates)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.MappedCandidates.Add(mappedCandidates);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(mappedCandidates);
        //}

        //// GET: MappedCandidates/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    MappedCandidates mappedCandidates = db.MappedCandidates.Find(id);
        //    if (mappedCandidates == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(mappedCandidates);
        //}

        //// POST: MappedCandidates/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,RequestId,CandidateId,MappedBy,Status,Cdate,ApprovalBy,ApprovalDate,VideoLinkSent,Video,VidUploadDate,VidStatus,VidApprovalBy,VidSubmissions,SentToClient,ApprovedByClient,ClientApprovalDate")] MappedCandidates mappedCandidates)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(mappedCandidates).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(mappedCandidates);
        //}

        //// GET: MappedCandidates/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    MappedCandidates mappedCandidates = db.MappedCandidates.Find(id);
        //    if (mappedCandidates == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(mappedCandidates);
        //}

        //// POST: MappedCandidates/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    MappedCandidates mappedCandidates = db.MappedCandidates.Find(id);
        //    db.MappedCandidates.Remove(mappedCandidates);
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
