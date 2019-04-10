
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Repository.Models
{
    public class CheckUserResponse
    {
        public CheckUserResponse(string id, string name, string mailAddress)
        {
            Id = id;
            Name = name;
            MailAddress = mailAddress;
        }

        public CheckUserResponse() { }

        public string Id { get; }

        public string Name { get; }

        public string MailAddress { get; }
    }
}