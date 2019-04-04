using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Models
{
    public class User
    {
        public User(string id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }

        public string Id { get; }

        public string Name { get; }

        public string Address { get; }
    }
}