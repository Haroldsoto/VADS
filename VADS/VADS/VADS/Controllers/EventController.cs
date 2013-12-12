using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VADS.Models;
using Google.GData.Calendar;
using Google.GData.Client;
using Google.GData.Extensions;

namespace VADS.Controllers
{
    public class EventController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Event/

        public ActionResult Index()
        {
            var eventmodels = db.EventModels.Include(e => e.VehicleInfo);
            return View(eventmodels.ToList());
        }

        //
        // GET: /Event/Details/5

        public ActionResult Details(int id = 0)
        {
            EventModel eventmodel = db.EventModels.Find(id);
            if (eventmodel == null)
            {
                return HttpNotFound();
            }
            return View(eventmodel);
        }

        //
        // GET: /Event/Create

        public ActionResult Create(int value, string type, int vehicleid)
        {
            var ev = new EventModel()
            {
                VehicleId = vehicleid,
                Value = value,
                Type = type
            };
            ViewBag.VehicleId = new SelectList(db.VehicleInfoModels, "VehicleId", "VehicleBrand");
            return View();
        }

        public ActionResult Add(int value, string type, int vehicleid)
        {
            var ev = new EventModel()
            {
                VehicleId = vehicleid,
                Value = value,
                Type = type,
                Time = DateTime.Now.AddHours(-4)
            };
                db.EventModels.Add(ev);
                db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        //
        // POST: /Event/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventModel eventmodel)
        {
            if (ModelState.IsValid)
            {
                db.EventModels.Add(eventmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VehicleId = new SelectList(db.VehicleInfoModels, "VehicleId", "VehicleBrand", eventmodel.VehicleId);
            return View(eventmodel);
        }

        //
        // GET: /Event/Edit/5
        public ActionResult AddCalendarEvent(string titulo, string contenido, DateTime fecha)
        {
            CalendarService service = new CalendarService("VADS");
            service.setUserCredentials("VADSproject@gmail.com", "123QWE!@#qwe");
            EventEntry entry = new EventEntry();

            // Set the title and content of the entry.
            entry.Title.Text = titulo;
            entry.Content.Content = contenido;

            // Set a location for the event.
            Where eventLocation = new Where();
            eventLocation.ValueString = "Taller";
            entry.Locations.Add(eventLocation);

            When eventTime = new When(fecha, DateTime.Now.AddHours(1));
            entry.Times.Add(eventTime);

            Uri postUri = new Uri("https://www.google.com/calendar/feeds/default/private/full");

            // Send the request and receive the response:
            AtomEntry insertedEntry = service.Insert(postUri, entry);

            //insertedEntry.Title.Text = "COROOOO";
            //insertedEntry.Update();
            return RedirectToAction("Index", "home");

        }
        public ActionResult Edit(int id = 0)
        {
            EventModel eventmodel = db.EventModels.Find(id);
            if (eventmodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleId = new SelectList(db.VehicleInfoModels, "VehicleId", "VehicleBrand", eventmodel.VehicleId);
            return View(eventmodel);
        }

        //
        // POST: /Event/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EventModel eventmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehicleId = new SelectList(db.VehicleInfoModels, "VehicleId", "VehicleBrand", eventmodel.VehicleId);
            return View(eventmodel);
        }

        //
        // GET: /Event/Delete/5

        public ActionResult Delete(int id = 0)
        {
            EventModel eventmodel = db.EventModels.Find(id);
            if (eventmodel == null)
            {
                return HttpNotFound();
            }
            return View(eventmodel);
        }

        //
        // POST: /Event/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventModel eventmodel = db.EventModels.Find(id);
            db.EventModels.Remove(eventmodel);
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