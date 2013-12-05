using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Mailer;
using VADS.Mailers;
using VADS.Models;

namespace VADS.Controllers
{
    public class MaintenanceController : Controller
    {
        //
        // GET: /Maintenance/
        private IUserMailer _userMailer = new UserMailer();
        public IUserMailer UserMailer
        {
            get{return _userMailer;}
            set{_userMailer = value;}
        }
        public ActionResult Index()
        {
            return View();
        }
        private UsersContext db = new UsersContext();
        public ActionResult SendMaintenanceMessage(int vehicleId, string mant)
        {
            var vehicle = db.VehicleInfoModels.FirstOrDefault(v => v.VehicleId == vehicleId);
            var name = vehicle.OwnerModel.Name;
            var lastName = vehicle.OwnerModel.LastName;
            var email = vehicle.OwnerModel.Email;
            var vehicleInfo = vehicle.VehicleBrand + " " + vehicle.VehicleModel + " " + vehicle.Year;
            var maintenance = 
            //UserMailer.Maintenance("mamodom@gmail.com", "Maximo", "Dominguez", "Mitsubishi Montero 2005", "Oil change").Send();
            //UserMailer.Maintenance("haroldsoto30@gmail.com", "Harold", "Soto", "Toyota Camry 2008", "Oil change").Send();
            //UserMailer.Maintenance("jose.lopez.c@gmail.com", "Jose Miguel", "Lopez", "Honda Civic 2004", "Oil change").Send();
            UserMailer.Maintenance(email, name, lastName, vehicleInfo, mant);
            return RedirectToAction("Index", "Home");
        }

    }
}
