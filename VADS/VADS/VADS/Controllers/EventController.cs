using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VADS.Models;

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

        public ActionResult Create()
        {
            ViewBag.VehicleId = new SelectList(db.VehicleInfoModels, "VehicleId", "VehicleBrand");
            return View();
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