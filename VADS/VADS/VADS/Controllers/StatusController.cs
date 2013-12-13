using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VADS.Mailers;
using VADS.Models;

namespace VADS.Controllers
{
    public class StatusController : Controller
    {
        private UsersContext db = new UsersContext();
        private IUserMailer _userMailer = new UserMailer();
        public IUserMailer UserMailer
        {
            get { return _userMailer; }
            set { _userMailer = value; }
        }
        
        // GET: /Status/

        public ActionResult Index()
        {
           // return null;
            var vehiclestatusmodels = db.VehicleStatusModels.Include(v => v.VehicleInfo);
            return View(vehiclestatusmodels.ToList());
        }

        //
        // GET: /Status/Details/5

        public ActionResult Details(int id = 0)
        {
            VehicleStatusModel vehiclestatusmodel = db.VehicleStatusModels.Find(id);
            if (vehiclestatusmodel == null)
            {
                return HttpNotFound();
            }
            return View(vehiclestatusmodel);
        }

        //
        // GET: /Status/Create

        public ActionResult Create()
        {
            ViewBag.VehicleId = new SelectList(db.VehicleInfoModels, "VehicleId", "VehicleBrand");
            return View();
        }
        
        //
        // POST: /Status/Create
        public VehicleInfoModel GetVehicleInfoByVehicleID(int? id)
        {
            return db.VehicleInfoModels.FirstOrDefault(model => model.VehicleId == id);
        }

        public ActionResult New(int vehicleId, string stat)
        {
            var mant = new ManteinanceModel()
            {
                Detail = stat,
                VehicleId = vehicleId,

            };
            db.ManteinanceModels.Add(mant);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }   

        public ActionResult Add(int? vehicleId, int? pidSpeed, int? pidRpm, int? pidThrottle, int? pidEngineLoad, int? pidAbsEngineLoad, int? pidCoolantTemp, int? pidIntakeTemp, int? pidIntakePressure, int? pidMafFlow, int? pidFuelPressure, int? pidFuelLevel, int? pidBarometric, int? pidTimingAdvance, int? pidRuntime, int? pidDistance)
        {
            var vehicleStatus = new VehicleStatusModel()
                                    {
                                        VehicleId = vehicleId,
                                        VehicleInfo = GetVehicleInfoByVehicleID(vehicleId),
                                        PidAbsEngineLoad = pidAbsEngineLoad,
                                        PidBarometric = pidBarometric,
                                        PidCoolantTemp = pidCoolantTemp,
                                        PidDistance = pidDistance,
                                        PidEngineLoad = pidEngineLoad,
                                        PidFuelLevel = pidFuelLevel,
                                        PidFuelPressure = pidFuelPressure,
                                        PidIntakePressure = pidIntakePressure,
                                        PidIntakeTemp = pidIntakeTemp,
                                        PidMafFlow = pidMafFlow,
                                        PidRpm = pidRpm,
                                        PidSpeed = pidSpeed,
                                        PidRuntime = pidRuntime,
                                        PidThrottle = pidThrottle,
                                        PidTimingAdvance = pidTimingAdvance,
                                        Time = DateTime.Now.AddHours(-4)
                                    };

            db.VehicleStatusModels.Add(vehicleStatus);
            db.SaveChanges();
            
            if(vehicleStatus.PidRpm > 2000)
            {
                var mant = new ManteinanceModel()
                               {
                                   Detail = "RPM High",
                                   MaintenanceId = 1,
                                   VehicleId = (int) vehicleStatus.VehicleId

                               };
                //db.ManteinanceModels.Add(mant);
                //db.SaveChanges();
                //UserMailer.Maintenance("jose.lopez.c@gmail.com", "Jose Miguel", "Lopez", "Honda Civic 2004", "Oil change").Send();
                UserMailer.Maintenance(vehicleStatus.VehicleInfo.OwnerModel.Email,
                                       vehicleStatus.VehicleInfo.OwnerModel.Name,
                                       vehicleStatus.VehicleInfo.OwnerModel.LastName,
                                       vehicleStatus.VehicleInfo.VehicleBrand + " " + vehicleStatus.VehicleInfo.VehicleModel + " " + 
                                       vehicleStatus.VehicleInfo.Year, mant.Detail,0,0/*todo: parameters*/).Send();
            }
            
            
            return RedirectToAction("Index", "Home");
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleStatusModel vehiclestatusmodel)
        {
            if (ModelState.IsValid)
            {
                db.VehicleStatusModels.Add(vehiclestatusmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VehicleId = new SelectList(db.VehicleInfoModels, "VehicleId", "VehicleBrand", vehiclestatusmodel.VehicleId);
            return View(vehiclestatusmodel);
        }

        //
        // GET: /Status/Edit/5

        public ActionResult Edit(int id = 0)
        {
            VehicleStatusModel vehiclestatusmodel = db.VehicleStatusModels.Find(id);
            if (vehiclestatusmodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleId = new SelectList(db.VehicleInfoModels, "VehicleId", "VehicleBrand", vehiclestatusmodel.VehicleId);
            return View(vehiclestatusmodel);
        }

        //
        // POST: /Status/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VehicleStatusModel vehiclestatusmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiclestatusmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehicleId = new SelectList(db.VehicleInfoModels, "VehicleId", "VehicleBrand", vehiclestatusmodel.VehicleId);
            return View(vehiclestatusmodel);
        }

        //
        // GET: /Status/Delete/5

        public ActionResult Delete(int id = 0)
        {
            VehicleStatusModel vehiclestatusmodel = db.VehicleStatusModels.Find(id);
            if (vehiclestatusmodel == null)
            {
                return HttpNotFound();
            }
            return View(vehiclestatusmodel);
        }

        //
        // POST: /Status/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleStatusModel vehiclestatusmodel = db.VehicleStatusModels.Find(id);
            db.VehicleStatusModels.Remove(vehiclestatusmodel);
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