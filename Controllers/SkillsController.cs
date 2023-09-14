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
    public class SkillsController : Controller
    {
        private EducareContext db = new EducareContext();

        // GET: Skills
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillView skill = db.SkillView.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

       
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Skill skill)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    skill.Status = true;
                    skill.SkillCode = AllProcs.GenerateSkillCode(skill.SubjectId, skill.LevelId, skill.AffiliationId);
                    db.Skills.Add(skill);
                    db.SaveChanges();
                    TempData["Msg"] = "1";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = MyFunctions.HandleMyError(ex);
                    return View(skill);
                }
                
            }

            return View(skill);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill skill = db.Skills.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Skill skill)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(skill).State = EntityState.Modified;
                    skill.SkillCode = AllProcs.GenerateSkillCode(skill.SubjectId, skill.LevelId, skill.AffiliationId);
                    db.SaveChanges();
                    TempData["Msg"] = "2";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = MyFunctions.HandleMyError(ex);
                    return View(skill);
                }
                
            }
            return View(skill);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillView skill = db.SkillView.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Skill skill = db.Skills.Find(id);
            db.Skills.Remove(skill);
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
