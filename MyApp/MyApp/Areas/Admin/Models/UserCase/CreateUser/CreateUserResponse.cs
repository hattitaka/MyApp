using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Models.UserCase.CreateUser
{
    public class CreateUserResponse
    {
        public CreateUserResponse(string name, string loginId, string password, string mailAddress)
        {
            Name = name;
            LoginId = loginId;
            Password = password;
            MailAddress = mailAddress;
        }

        public string Name { get; }

        public string LoginId { get; }

        public string Password { get; }

        public string MailAddress { get; }
    }
}