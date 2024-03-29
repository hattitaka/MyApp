﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Repository.Models
{
    public class RegisterUserRequest
    {
        public RegisterUserRequest(string loginId, string name, string mailAddress, string password)
        {
            LoginId = loginId;
            Name = name;
            MailAddress = mailAddress;
            Password = password;
        }

        public string LoginId { get; }

        public string Name { get; }

        public string MailAddress { get; }

        public string Password { get; }
    }
}