
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Repository.Models
{
    public class CheckUserRequest
    {
        public CheckUserRequest(string loginId, string address)
        {
            LoginId = loginId;
            Address = address;
        }

        public string LoginId { get; }

        public string Address { get; }
    }
}