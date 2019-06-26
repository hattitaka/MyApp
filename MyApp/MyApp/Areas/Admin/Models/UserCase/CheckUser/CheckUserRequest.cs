using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Models.UserCase.CheckUser
{
    public class CheckUserRequest
    {
        public CheckUserRequest(string loginId, string password)
        {
            LoginId = loginId;
            Password = password;
        }

        public string LoginId { get; set; }

        public string Password { get; set; }
    }
}