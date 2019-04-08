using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Models
{
    public class UserDetails
    {
        public UserDetails(string id, string loginId, string name, string mailAddress)
        {
            Id = id;
            LoginId = loginId;
            Name = name;
            MailAddress = mailAddress;
        }

        public string Id { get; set; }

        public string LoginId { get; set; }

        public string Name { get; set; }

        public string MailAddress { get; set; }
    }
}