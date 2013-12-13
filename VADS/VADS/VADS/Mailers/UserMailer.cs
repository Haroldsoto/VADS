using System;
using Mvc.Mailer;
using VADS.Models;

namespace VADS.Mailers
{
    public class UserMailer : MailerBase, IUserMailer
    {
        readonly UsersContext _db = new UsersContext();

        public UserMailer()
        {
            MasterName = "_Layout";
        }

        public virtual MvcMailMessage Maintenance(string clientMail, string clientName, string clientLastName, string vehicle, string maintenance, int vehicleId, int attendantId)
        {
            //ViewBag.Data = someObject;
            //string vehicleData = vehicle.VehicleBrand.ToString() + vehicle.VehicleModel.ToString() + vehicle.Year.ToString();
            //ViewBag.Vehicle = vehicleData;
            ViewBag.Vehicle = vehicle;
            ViewBag.Name = clientName;
            ViewBag.LastName = clientLastName;
            ViewBag.Maintenance = maintenance;



            var klk = Guid.NewGuid();

            _db.Appointments.Add(new Appointment
            {
                Id = klk,
                VehicleId = vehicleId,
                AttendantId = attendantId
            });

            ViewBag.Link = "http://vads.azurewebsites.net/" + klk;
            return Populate(x =>
            {
                x.Subject = maintenance + " Maintenance Required";
                x.ViewName = "Maintenance";
                x.To.Add(clientMail);

            });
        }

        public virtual MvcMailMessage PasswordReset()
        {
            //ViewBag.Data = someObject;
            return Populate(x =>
            {
                x.Subject = "PasswordReset";
                x.ViewName = "PasswordReset";
                x.To.Add("some-email@example.com");
            });
        }
    }
}