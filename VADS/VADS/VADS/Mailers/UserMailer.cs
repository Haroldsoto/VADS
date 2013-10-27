using Mvc.Mailer;
using VADS.Models;

namespace VADS.Mailers
{ 
    public class UserMailer : MailerBase, IUserMailer 	
	{
		public UserMailer()
		{
			MasterName="_Layout";
		}
		
		public virtual MvcMailMessage Maintenance(string clientMail, string clientName, string clientLastName, string vehicle,string maintenance)
		{
			//ViewBag.Data = someObject;
            //string vehicleData = vehicle.VehicleBrand.ToString() + vehicle.VehicleModel.ToString() + vehicle.Year.ToString();
            //ViewBag.Vehicle = vehicleData;
		    ViewBag.Vehicle = vehicle;
            ViewBag.Name = clientName;
		    ViewBag.LastName = clientLastName;
		    ViewBag.Maintenance = maintenance;
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