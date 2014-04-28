using System;
using Mvc.Mailer;
using VADS.Models;

namespace VADS.Mailers
{
    public interface IUserMailer
    {
        MvcMailMessage Maintenance(string clientMail, string clientName, string clientLastName, string vehicle,
            string maintenance);
        MvcMailMessage Connected(string clientMail, string clientName, string clientLastName, string vehicle);

        MvcMailMessage Alert(string message, string subject, string clientMail, string clientName, string clientLastName,
            string vehicle);

        MvcMailMessage Success(string clientMail, string clientName, 
            string vehicle, string maintenance, string hora, string fecha, string representante);
        MvcMailMessage PasswordReset();
    }
}