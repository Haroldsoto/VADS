using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VADS.Models;

namespace VADS.Controllers
{
    public class ClientController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Owner/

        public ActionResult Index()
        {
            //var attendants = db.UserProfiles.ToList();
            //var startDate = new DateTime(2013, 11, 1);
            //const int numberofDays = 30;
            //const int rounds = 9;

            //foreach (var userProfile in attendants)
            //{
            //    for (int i = 0; i < numberofDays; i++)
            //    {
            //        for (var j = 0; j < rounds; j++)
            //        {
            //            db.Appointments.AddOrUpdate(
            //                new Appointment
            //                {
            //                    UserProfile = userProfile,
            //                    AttendantId = userProfile.UserId,
            //                    Date = startDate.AddDays(i),
            //                    Id = Guid.NewGuid(),
            //                    Round = j,
            //                    Maintenance = null,
            //                    VehicleId = null,
            //                    VehicleInfoModel = null
            //                }
            //                );
            //        }
            //    }
            //}
            //db.SaveChanges();

            return View(db.OwnerModels.ToList());
        }

        //
        // GET: /Owner/Details/5

        public ActionResult Details(int id = 0)
        {
            OwnerModel ownermodel = db.OwnerModels.Find(id);
            if (ownermodel == null)
            {
                return HttpNotFound();
            }
            return View(ownermodel);
        }

        //
        // GET: /Owner/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Owner/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OwnerModel ownermodel)
        {
            if (ModelState.IsValid)
            {
                db.OwnerModels.Add(ownermodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ownermodel);
        }

        //
        // GET: /Owner/Edit/5

        public ActionResult Edit(int id = 0)
        {
            OwnerModel ownermodel = db.OwnerModels.Find(id);
            if (ownermodel == null)
            {
                return HttpNotFound();
            }
            return View(ownermodel);
        }

        public ActionResult MaintenanceSchedule(int? clientId)
        {
            return View();
        }



        //
        // POST: /Owner/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OwnerModel ownermodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ownermodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ownermodel);
        }

        //
        // GET: /Owner/Delete/5

        public ActionResult Delete(int id = 0)
        {
            OwnerModel ownermodel = db.OwnerModels.Find(id);
            if (ownermodel == null)
            {
                return HttpNotFound();
            }
            return View(ownermodel);
        }

        //
        // POST: /Owner/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OwnerModel ownermodel = db.OwnerModels.Find(id);
            db.OwnerModels.Remove(ownermodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}