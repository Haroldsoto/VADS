using System;
using System.Linq;
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

        public virtual MvcMailMessage Maintenance(string clientMail, string clientName, string clientLastName, string vehicle, string maintenance)
        {
            //ViewBag.Data = someObject;
            //string vehicleData = vehicle.VehicleBrand.ToString() + vehicle.VehicleModel.ToString() + vehicle.Year.ToString();
            //ViewBag.Vehicle = vehicleData;
            ViewBag.Vehicle = vehicle;
            ViewBag.Name = clientName;
            ViewBag.LastName = clientLastName;
            ViewBag.Maintenance = maintenance;

            var owner = _db.OwnerModels.FirstOrDefault(model => model.Email == clientMail);

            var invitation = new Invitation
            {
                Id = Guid.NewGuid(),
                OwnerModel = owner,
                UserId = owner.Id
            };

            _db.Invitations.Add(invitation);
            _db.SaveChanges();
            ViewBag.Link = "http://vads.azurewebsites.net/Appointment/Select?invitation=" + invitation.Id +
                           "&maintenance=" + maintenance;
            return Populate(x =>
            {
                x.Subject = maintenance;
                x.ViewName = "Maintenance";
                x.To.Add(clientMail);
            });
        }

        public virtual MvcMailMessage Connected(string clientMail, string clientName, string clientLastName, string vehicle)
        {
            ViewBag.Vehicle = vehicle;
            ViewBag.Name = clientName;
            ViewBag.LastName = clientLastName;
            
            return Populate(x =>
            {
                x.Subject = "VADS - Comunicación establecida.";
                x.ViewName = "Connected";
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