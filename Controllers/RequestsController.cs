using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EduCare.Models;
using Newtonsoft.Json;

namespace EduCare.Controllers
{
    public class RequestsController : Controller
    {
        private EducareContext db = new EducareContext();

        // GET: Requests
        public ActionResult Index()
        {
            return View();
        }

        // GET: Requests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestsView requests = db.RequestsView.Find(id);
            if (requests == null)
            {
                return HttpNotFound();
            }
            return View(requests);
        }

        // GET: Requests/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Requests requests, HttpPostedFileBase JD)
        {
            if (ModelState.IsValid)
            {
                if (JD != null && JD.ContentLength > 0)
                {
                    string ext = Path.GetExtension(JD.FileName);
                    string fileName = "JD_" + DateTime.Now.Ticks + ext;
                    string filePath = Path.Combine(Server.MapPath("~/UploadedFiles/JD/"), fileName);
                    JD.SaveAs(filePath);
                    requests.Jd = fileName;
                }
                requests.CreatedBy = MyFunctions.GetUid;
                requests.Cdate = DateTime.Now.Date;
                requests.CTime = MyFunctions.GetCurrentTime();
                requests.Recruiter = MyFunctions.GetUid;
                requests.AllotedBy = MyFunctions.GetUid;
                requests.AllotmentDate = DateTime.Now.Date;
                requests.AllotmentTime = DateTime.Now.Date;
                //requests.Status = MyFunctions.GetUid;

                db.Requests.Add(requests);
                db.SaveChanges();

                return RedirectToAction("Index");


            }
            return View(requests);
        }

        // GET: Requests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requests requests = db.Requests.Find(id);
            if (requests == null)
            {
                return HttpNotFound();
            }
            return View(requests);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Requests requests)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(requests).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["Msg"] = "2";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["msg"] = MyFunctions.HandleMyError(ex);
                    return View(requests);
                }

            }
            return View(requests);
        }

        //// GET: Requests/Delete/5
        ////public ActionResult Delete(int? id)
        ////{
        ////    if (id == null)
        ////    {
        ////        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        ////    }
        ////    Requests requests = db.Requests.Find(id);
        ////    if (requests == null)
        ////    {
        ////        return HttpNotFound();
        ////    }
        ////    return View(requests);
        ////}

        //// POST: Requests/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Requests requests = db.Requests.Find(id);
        //    db.Requests.Remove(requests);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public ActionResult AllotReruiter(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestsView requests = db.RequestsView.Find(id);
            if (requests == null)
            {
                return HttpNotFound();
            }
            return View(requests);
        }
        public ActionResult Mapcandidate()
        {
            return View();
        }
        public static void AddMappedcandidate(int? RequestId, int? CandidateId)
        {
            AllProcs.AddMappedcandidate(RequestId, CandidateId);
        }
        public string GetClientbyId(int? Id)
        {
            return JsonConvert.SerializeObject(AllProcs.GetClientDetailsById(Id));
        }

        public string GetContactPersonbyClientId(int? CId)
        {
            return JsonConvert.SerializeObject(AllProcs.GetContactPersonbyClientId(CId));
        }
        public string GetSkillbyId(int? skillId)
        {
            return JsonConvert.SerializeObject(AllProcs.GetSkillbyId(skillId));
        }

        public string GetContactPersonById(int? Id)
        {
            return JsonConvert.SerializeObject(AllProcs.GetContactPersonById(Id));
        }

        //public PartialViewResult AddNewClient()
        //{
        //    return PartialView();
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
