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
    public class CandidatesController : Controller
    {
        private EducareContext db = new EducareContext();

        // GET: Candidates
        public ActionResult Index()
        {
            return View();
        }

        // GET: Candidates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateView candidate = db.CandidateView.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // GET: Candidates/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Candidate candidate, HttpPostedFileBase Resume)
        {
            if (ModelState.IsValid)
            {
                if (Resume != null && Resume.ContentLength > 0)
                {
                    string ext = Path.GetExtension(Resume.FileName);
                    string fileName = "Resumes_" + DateTime.Now.Ticks + ext;
                    string filePath = Path.Combine(Server.MapPath("~/UploadedFiles/Resumes"), fileName);
                    Resume.SaveAs(filePath);
                    candidate.Resume = fileName;
                }
                db.Candidates.Add(candidate);
                db.SaveChanges();

                int id = candidate.Id;

                string[] specialization = Request["GSpecialization"].Split(',').ToArray();
                int[] degree = Request["GDegreeId"].Split(',').Select(x => Convert.ToInt32(x)).ToArray();
                int[] university = Request["GUniversityId"].Split(',').Select(x => Convert.ToInt32(x)).ToArray();
                string[] school = Request["GSchoolName"].Split(',').ToArray();
                DateTime[] startdate = Request["GStartDate"].Split(',').Select(x => Convert.ToDateTime(x)).ToArray();
                DateTime[] enddate = Request["GEnddate"].Split(',').Select(x => Convert.ToDateTime(x)).ToArray();



                List<Education> educations = new List<Education>();
                for (int i = 0; i < specialization.Length; i++)
                {
                    Education education = new Education
                    {
                        CandidateId = id,
                        DegreeId = degree[i],
                        Specialization = specialization[i],
                        UniversityId = university[i],
                        SchoolName = school[i],
                        StartDate = startdate[i],
                        Enddate = enddate[i]
                    };
                    educations.Add(education);
                }

                string[] Organization = Request["Organization"].Split(',').ToArray();
                string[] Designation = Request["Designation"].Split(',').ToArray();
                DateTime[] Startdate = Request["Startdate"].Split(',').Select(x => Convert.ToDateTime(x)).ToArray();
                DateTime[] Enddate = Request["Enddate"].Split(',').Select(x => Convert.ToDateTime(x)).ToArray();

                List<WorkExperiance> workExperiances = new List<WorkExperiance>();
                for (int i = 0; i < Organization.Length; i++)
                {
                    WorkExperiance workExperiance = new WorkExperiance
                    {
                        CandidateId = id,
                        Organization = Organization[i],
                        Designation = Designation[i],
                        Startdate = Startdate[i],
                        Enddate = Enddate[i]
                    };
                    workExperiances.Add(workExperiance);
                }
                db.Education.AddRange(educations);
                db.WorkExperiance.AddRange(workExperiances);
                db.SaveChanges();
                TempData["Msg"] = "1";
                return RedirectToAction("Index");
            }

            return View(candidate);
        }

        // GET: Candidates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Candidate candidate, string EdudeletedIds, string WorkexperiancedelIds,HttpPostedFileBase Resume)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Resume != null && Resume.ContentLength > 0)
                    {
                        string ext = Path.GetExtension(Resume.FileName);
                        string fileName = "Resumes_" + DateTime.Now.Ticks + ext;
                        string filePath = Path.Combine(Server.MapPath("~/UploadedFiles/Resumes"), fileName);
                        Resume.SaveAs(filePath);
                        candidate.Resume = fileName;
                    }
                    db.Entry(candidate).State = EntityState.Modified;
                    db.SaveChanges();

                    int CandidateId = candidate.Id;

                    int[] Id = Request["GId"].Split(',').Select(x => Convert.ToInt32(x)).ToArray();


                    string[] specialization = Request["GSpecialization"].Split(',').ToArray();
                    int[] degree = Request["GDegreeId"].Split(',').Select(x => Convert.ToInt32(x)).ToArray();
                    int[] university = Request["GUniversityId"].Split(',').Select(x => Convert.ToInt32(x)).ToArray();
                    string[] school = Request["GSchoolName"].Split(',').ToArray();
                    DateTime[] startdate = Request["GStartDate"].Split(',').Select(x => Convert.ToDateTime(x)).ToArray();
                    DateTime[] enddate = Request["GEnddate"].Split(',').Select(x => Convert.ToDateTime(x)).ToArray();



                    for (int i = 0; i < Id.Length; i++)
                    {
                        AllProcs.AddUpdateEducation(Id[i], CandidateId, degree[i], specialization[i], university[i], school[i], startdate[i], enddate[i]);
                    }
                    if (!string.IsNullOrEmpty(EdudeletedIds))
                    {
                        AllProcs.DeleteEducation(EdudeletedIds);
                    }

                    //...................Work Experiance....................
                    int cndId = candidate.Id;

                    int[] WId = Request["wGId"].Split(',').Select(x => Convert.ToInt32(x)).ToArray();

                    string[] Organization = Request["Organization"].Split(',').ToArray();
                    string[] Designation = Request["Designation"].Split(',').ToArray();
                    DateTime[] Startdate = Request["Startdate"].Split(',').Select(x => Convert.ToDateTime(x)).ToArray();
                    DateTime[] Enddate = Request["Enddate"].Split(',').Select(x => Convert.ToDateTime(x)).ToArray();

                    for (int i = 0; i < WId.Length; i++)
                    {
                        AllProcs.AddUpdateWorkExperiance(WId[i], cndId, Organization[i], Designation[i], Startdate[i], Enddate[i]);
                    }
                    if (!string.IsNullOrEmpty(WorkexperiancedelIds))
                    {
                        AllProcs.DeleteWorkExperiance(WorkexperiancedelIds);
                    }
                    TempData["Msg"] = "2";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = MyFunctions.HandleMyError(ex);
                    return View(candidate);
                }

            }
            return View(candidate);
        }

        // GET: Candidates/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Candidate candidate = db.Candidates.Find(id);
        //    if (candidate == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(candidate);
        //}

        //// POST: Candidates/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Candidate candidate = db.Candidates.Find(id);
        //    db.Candidates.Remove(candidate);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public string StateChoice(int? Cid)
        {
            return JsonConvert.SerializeObject(AllProcs.StateChoice(Cid));
        }

        public string GetSkillbyId(int? skillId)
        {
            return JsonConvert.SerializeObject(AllProcs.GetSkillbyId(skillId));
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
