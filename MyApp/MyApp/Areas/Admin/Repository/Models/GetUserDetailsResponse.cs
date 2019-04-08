using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Repository.Models
{
    public class GetUserDetailsResponse
    {
        public GetUserDetailsResponse(string name, string address, string loginId)
        {
            Name = name;
            Address = address;
            LoginId = loginId;
        }

        public string Name { get; }

        public string Address { get; }

        public string LoginId { get; }
    }
}