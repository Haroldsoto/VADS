using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;
using VADS.Models;

namespace VADS.Controllers
{
    public class AppointmentController : Controller
    {
        private UsersContext db = new UsersContext();


        public ActionResult Select(Guid invitation, string maintenance)
        {
            var owner = db.Invitations.FirstOrDefault(invitation1 => invitation1.Id == invitation).OwnerModel;
            ViewBag.ownerId = owner.Id;
            ViewBag.Maintenance = maintenance;
            var appointments = db.Appointments.Where(appointment => appointment.VehicleId == null);
            return View(appointments);
        }


        //
        // GET: /Appointment/

        public ActionResult Index()
        {
            var appointments = db.Appointments.Include(a => a.UserProfile).Include(a => a.VehicleInfoModel);
            return View(appointments.Where(appointment => appointment.VehicleId == null).Take(10).ToList());
        }

        //
        // GET: /Appointment/

        public ActionResult Existing()
        {
            var appointments = db.Appointments.Include(a => a.UserProfile).Include(a => a.VehicleInfoModel);
            return View(appointments.Where(appointment => appointment.VehicleId != null).ToList());
        }

        //
        // GET: /Appointment/Details/5

        public ActionResult Details(Guid id)
        {
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        //
        // GET: /Appointment/Create

        public ActionResult Create()
        {
            ViewBag.AttendantId = new SelectList(db.UserProfiles, "UserId", "UserName");
            ViewBag.VehicleId = new SelectList(db.VehicleInfoModels, "VehicleId", "Year");
            return View();
        }

        //
        // POST: /Appointment/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                appointment.Id = Guid.NewGuid();
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AttendantId = new SelectList(db.UserProfiles, "UserId", "UserName", appointment.AttendantId);
            ViewBag.VehicleId = new SelectList(db.VehicleInfoModels, "VehicleId", "Year", appointment.VehicleId);
            return View(appointment);
        }

        //
        // GET: /Appointment/Edit/5

        public ActionResult Edit(Guid id)
        {
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.AttendantId = new SelectList(db.UserProfiles, "UserId", "UserName", appointment.AttendantId);
            ViewBag.VehicleId = new SelectList(db.VehicleInfoModels, "VehicleId", "Year", appointment.VehicleId);
            return View(appointment);
        }

        //
        // POST: /Appointment/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AttendantId = new SelectList(db.UserProfiles, "UserId", "UserName", appointment.AttendantId);
            ViewBag.VehicleId = new SelectList(db.VehicleInfoModels, "VehicleId", "Year", appointment.VehicleId);
            return View(appointment);
        }

        //
        // GET: /Appointment/Delete/5

        public ActionResult Delete(Guid id)
        {
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        //
        // POST: /Appointment/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Appointment appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Seleccionar(int ownerId, Guid appointmentId, string maintenance)
        {
            var vehicleinfomodel = db.VehicleInfoModels.FirstOrDefault(model => model.OwnerId == ownerId);

            var selectedAppoint = db.Appointments.First(appointment => appointment.Id == appointmentId);
            selectedAppoint.VehicleId = vehicleinfomodel.VehicleId;
            selectedAppoint.Maintenance = maintenance;

            db.Appointments.AddOrUpdate(selectedAppoint);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}