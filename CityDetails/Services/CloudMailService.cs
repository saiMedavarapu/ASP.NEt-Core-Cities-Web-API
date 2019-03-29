using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CityDetails.Services
{
    public class CloudMailService:IMailService
    {

        private string _mailTo = "mailsettings: mailToAddress";
        private string _mailFrom = "mailsettings: mailFromAddress";

        public void Send(string subject, string message)
        {
            Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with LocalMailService");
            Debug.WriteLine($"Subject: {subject}");
            Debug.WriteLine($"Message: {message}");
        }
    }
}
