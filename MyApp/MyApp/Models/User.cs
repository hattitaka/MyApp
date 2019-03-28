using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Models
{
    public class User
    {
        public User(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; }

        public string Name { get; }
    }
}