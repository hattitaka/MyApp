using MyApp.Areas.Admin.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Models.UserCase.ChangeUserInfo
{
    public class ChangeUserInfoRequest
    {
        public ChangeUserInfoRequest(string id, string name, string mailAddress, string password)
        {
            Id = id;
            Name = name;
            MailAddress = mailAddress;
            Password = password;
        }

        public string Id { get; }

        public string Name { get; }

        public string MailAddress { get; }

        public string Password { get; }
    }
}