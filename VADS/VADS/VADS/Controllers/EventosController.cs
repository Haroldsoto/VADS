using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VADS.Mailers;
using VADS.Models;

namespace VADS.Controllers
{
    // [Authorize(Roles = "canEdit")]
    public class EventosController : Controller
    {
        private IUserMailer _userMailer = new UserMailer();
        private UsersContext db = new UsersContext();
        public IUserMailer UserMailer
        {
            get { return _userMailer; }
            set { _userMailer = value; }
        }

        //
        // GET: /Eventos/

        public ActionResult Index()
        {
            var eventmodels = db.EventModels.Include(e => e.VehicleInfo.VehicleModel.VehicleBrand).Include(e1 => e1.VehicleInfo.OwnerModel).OrderByDescending(model => model.EventID);
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
            var vehicle = db.VehicleInfoModels.FirstOrDefault(v => v.VehicleId == vehicleid);
            var name = vehicle.OwnerModel.Name;
            var lastName = vehicle.OwnerModel.LastName;
            var email = vehicle.OwnerModel.Email;
            var vehicleInfo = vehicle.VehicleModel.VehicleBrand.Brand + " " + vehicle.VehicleModel.Model + " " + vehicle.Year;
            var model = new EventModel
            {
                Value = value, Type = type, VehicleId = vehicleid,
                Time = DateTime.UtcNow.AddHours(-4)
            };
            switch (type)
            {
                case "KPH_MAYOR":
                    UserMailer.Maintenance(email, name, lastName, vehicleInfo, "Velocidad mayor que:" + value.ToString() + " Km/h").Send();
                    break;
                case "DISTANCIA_MAYOR":
                    UserMailer.Maintenance(email, name, lastName, vehicleInfo, "Distancia recorrida mayor que:" + value.ToString() + " Km").Send();
                    break;
                case "TEMP_NORMAL":
                    UserMailer.Maintenance(email, name, lastName, vehicleInfo, "Temperatura mayor que:" + value.ToString() + " Km").Send();
                    break;
                case "OIL_CHANGE":
                    UserMailer.Maintenance(email, name, lastName, vehicleInfo, "Cambio de aceite").Send();
                    break;
                case "RPM_MAYOR":
                    UserMailer.Maintenance(email, name, lastName, vehicleInfo, "Revoluciones por minuto mayor que: " + value.ToString()).Send();
                    break;
                case "FUEL_MENOR":
                    UserMailer.Maintenance(email, name, lastName, vehicleInfo, "Nivel de combustible: " + value.ToString()).Send();
                    break;
                case "OBDConnected":
                    UserMailer.Connected(email, name, lastName, vehicleInfo).Send();
                    break;
                case "VEHICLE_ON":
                    UserMailer.Alert("ha sido encendido.", "Vehículo Encendido",email, name, lastName, vehicleInfo).Send();
                    break;
            }
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