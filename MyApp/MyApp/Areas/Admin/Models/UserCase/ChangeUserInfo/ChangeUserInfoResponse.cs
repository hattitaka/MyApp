using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Models.UserCase.ChangeUserInfo
{
    public class ChangeUserInfoResponse: ResponseBase
    {
        public ChangeUserInfoResponse(string name, string mailAddress, string password)
        {
            Name = name;
            MailAddress = mailAddress;
            Password = password;
        }

        public string Name { get; }

        public string MailAddress { get; }

        public string Password { get; }
    }
}