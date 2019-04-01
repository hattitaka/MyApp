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

        public string Id { get; }

        public string LoginId { get; }

        public string Name { get; }

        public string MailAddress { get; }
    }
}