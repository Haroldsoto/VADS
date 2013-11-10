using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VADS.Models;

namespace VADS.Controllers
{
    
    public class VehicleController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /vehicle/

        public ActionResult Index()
        {
            var vehicleinfomodels = db.VehicleInfoModels.Include(v => v.OwnerModel);
            return View(vehicleinfomodels.ToList());
        }

        //
        // GET: /vehicle/Details/5

        public ActionResult Details(int id = 0)
        {
            VehicleInfoModel vehicleinfomodel = db.VehicleInfoModels.Find(id);
            if (vehicleinfomodel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleinfomodel);
        }

        public ActionResult GetModels()
        {
            return null;
        }

        //
        // GET: /vehicle/Create

        public ActionResult Create()
        {
            ViewBag.VehicleBrands = new SelectList(db.VehicleBrandses, "BrandId", "Brand");
            ViewBag.VehicleModels = new SelectList(db.VehicleModelses, "BrandId", "Model");
            ViewBag.OwnerId = new SelectList(db.OwnerModels, "Id", "Name");
            return View();
        }
        public JsonResult GetStates(int id)
        {
            var modelsList = new SelectList(db.VehicleModelses, "BrandId", "Model").ToList().Where(item => item.Value == id.ToString(CultureInfo.InvariantCulture));
            return this.Json(modelsList, JsonRequestBehavior.AllowGet);
        }


        //
        // POST: /vehicle/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleInfoModel vehicleinfomodel)
        {
            //if (ModelState.IsValid)
            //{
                db.VehicleInfoModels.Add(vehicleinfomodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            //}

            //ViewBag.OwnerId = new SelectList(db.OwnerModels, "Id", "Name", vehicleinfomodel.OwnerId);
            //return View(vehicleinfomodel);
        }

        //
        // GET: /vehicle/Edit/5

        public ActionResult Edit(int id = 0)
        {
            VehicleInfoModel vehicleinfomodel = db.VehicleInfoModels.Find(id);
            if (vehicleinfomodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerId = new SelectList(db.OwnerModels, "Id", "Name", vehicleinfomodel.OwnerId);
            return View(vehicleinfomodel);
        }

        //
        // POST: /vehicle/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VehicleInfoModel vehicleinfomodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleinfomodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerId = new SelectList(db.OwnerModels, "Id", "Name", vehicleinfomodel.OwnerId);
            return View(vehicleinfomodel);
        }

        //
        // GET: /vehicle/Delete/5

        public ActionResult Delete(int id = 0)
        {
            VehicleInfoModel vehicleinfomodel = db.VehicleInfoModels.Find(id);
            if (vehicleinfomodel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleinfomodel);
        }

        //
        // POST: /vehicle/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleInfoModel vehicleinfomodel = db.VehicleInfoModels.Find(id);
            db.VehicleInfoModels.Remove(vehicleinfomodel);
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