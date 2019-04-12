using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Repository.Models
{
    public class SaveUserChangeRequest
    {
        public SaveUserChangeRequest(string id, string loginId, string name, string address)
        {
            Id = id;
            LoginId = loginId;
            Name = name;
            Address = address;
        }

        public string Id { get; }

        public string LoginId { get; }

        public string Name { get; }

        public string Address { get; }
    }
}