using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EduCare.Models;
using Newtonsoft.Json;

namespace EduCare.Controllers
{
    public class ClientsController : Controller
    {
        private EducareContext db = new EducareContext();

        // GET: Client
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
            ClientView Client = db.ClientView.Find(id);
            if (Client == null)
            {
                return HttpNotFound();
            }
            return View(Client);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client Client)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Client.Status = true;
                    db.Client.Add(Client);
                    db.SaveChanges();

                    int id = Client.Id;

                    string[] name = Request["GName"].Split(',').ToArray();
                    int[] deptid = Request["GDepartmentId"].Split(',').Select(x => Convert.ToInt32(x)).ToArray();
                    int[] desiid = Request["GDesignationId"].Split(',').Select(x => Convert.ToInt32(x)).ToArray();
                    string[] email = Request["GEmail"].Split(',').ToArray();
                    string[] mobile = Request["GContactNo"].Split(',').ToArray();
                    string[] whatsapp = Request["GWhatsAppNo"].Split(',').ToArray();

                    List<ContactPerson> contacts = new List<ContactPerson>();
                    for (int i = 0; i < name.Length; i++)
                    {
                        ContactPerson contactPerson = new ContactPerson
                        {
                            ClientId = id,
                            Name = name[i],
                            DepartmentId = deptid[i],
                            DesignationId = desiid[i],
                            Email = email[i],
                            ContactNo = mobile[i],
                            WhatsAppNo = whatsapp[i]
                        };
                        contacts.Add(contactPerson);
                    }
                    db.ContactPerson.AddRange(contacts);
                    db.SaveChanges();
                    TempData["msg"] = "1";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = MyFunctions.HandleMyError(ex);
                    return View(Client);
                }

            }
            return View(Client);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client Client = db.Client.Find(id);
            if (Client == null)
            {
                return HttpNotFound();
            }
            return View(Client);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Client Client, string DeletedIds)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(Client).State = EntityState.Modified;
                    db.SaveChanges();

                    int ClientId = Client.Id;

                    int[] Id = Request["GId"].Split(',').Select(x => Convert.ToInt32(x)).ToArray();

                    string[] name = Request["GName"].Split(',').ToArray();
                    int[] deptid = Request["GDepartmentId"].Split(',').Select(x => Convert.ToInt32(x)).ToArray();
                    int[] desiid = Request["GDesignationId"].Split(',').Select(x => Convert.ToInt32(x)).ToArray();
                    string[] email = Request["GEmail"].Split(',').ToArray();
                    string[] mobile = Request["GContactNo"].Split(',').ToArray();
                    string[] whatsapp = Request["GWhatsAppNo"].Split(',').ToArray();

                    for (int i = 0; i < Id.Length; i++)
                    {
                        AllProcs.AddUpdateContactPerson(Id[i], ClientId, name[i], desiid[i], deptid[i], email[i], mobile[i], whatsapp[i]);
                    }

                    if (!string.IsNullOrEmpty(DeletedIds))
                    {
                        AllProcs.DeleteContactPersons(DeletedIds);
                    }

                    TempData["Msg"] = "2";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = MyFunctions.HandleMyError(ex);
                    return View(Client);
                }
                
            }
            return View(Client);
        }
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Client Client = db.Client.Find(id);
        //    if (Client == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(Client);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Client Client = db.Client.Find(id);
        //    db.Client.Remove(Client);
        //    db.SaveChanges();
        //    TempData["Msg"] = "3";
        //    return RedirectToAction("Index");
        //}

        public string StateChoice(int? Cid)
        {
            return JsonConvert.SerializeObject(AllProcs.StateChoice(Cid));
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
