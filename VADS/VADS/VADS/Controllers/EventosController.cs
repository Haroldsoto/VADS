using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VADS.Models;

namespace VADS.Controllers
{
    public class EventosController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Eventos/

        public ActionResult Index()
        {
            var eventmodels = db.EventModels.Include(e => e.VehicleInfo);
            return View(eventmodels.ToList());
        }

        //
        // GET: /Eventos/Details/5

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
        // GET: /Eventos/Create

        public ActionResult Create()
        {
            ViewBag.VehicleId = new SelectList(db.VehicleInfoModels, "VehicleId", "Year");
            return View();
        }

        //
        // POST: /Eventos/Create

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

            ViewBag.VehicleId = new SelectList(db.VehicleInfoModels, "VehicleId", "Year", eventmodel.VehicleId);
            return View(eventmodel);
        }

        public ActionResult Add(int value, string type, int vehicleid)
        {
            var model = new EventModel
            {
                Value = value, Type = type, VehicleId = vehicleid,
                Time = DateTime.UtcNow
            };
            
            db.EventModels.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Eventos/Edit/5

        public ActionResult Edit(int id = 0)
        {
            EventModel eventmodel = db.EventModels.Find(id);
            if (eventmodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleId = new SelectList(db.VehicleInfoModels, "VehicleId", "Year", eventmodel.VehicleId);
            return View(eventmodel);
        }

        //
        // POST: /Eventos/Edit/5

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
            ViewBag.VehicleId = new SelectList(db.VehicleInfoModels, "VehicleId", "Year", eventmodel.VehicleId);
            return View(eventmodel);
        }

        //
        // GET: /Eventos/Delete/5

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
        // POST: /Eventos/Delete/5

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