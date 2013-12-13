using Mvc.Mailer;
using VADS.Models;

namespace VADS.Mailers
{
    public interface IUserMailer
    {
        MvcMailMessage Maintenance(string clientMail, string clientName, string clientLastName, string vehicle,
            string maintenance);

        MvcMailMessage PasswordReset();
    }
}