
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Repository.Models
{
    public class CheckUserRequest
    {
        public CheckUserRequest(string loginId, string password)
        {
            LoginId = loginId;
            Password = password;
        }

        public string LoginId { get; }

        public string Password { get; }
    }
}