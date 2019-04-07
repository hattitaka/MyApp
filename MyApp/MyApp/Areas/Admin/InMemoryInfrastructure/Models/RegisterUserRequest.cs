using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.InMemoryInfrastructure.Models
{
    public class RegisterUserRequest
    {
        public RegisterUserRequest(string loginId, string name, string mailAddress)
        {
            LoginId = loginId;
            Name = name;
            MailAddress = mailAddress;
        }

        public string LoginId { get; }

        public string Name { get; }

        public string MailAddress { get; }
    }
}