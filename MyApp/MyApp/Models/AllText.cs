using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Models
{
    public class AllText
    {
        public AllText(string userId, string title, string description, string profile_1)
        {
            UserId = userId;
            Title = title;
            Description = description;
            Profile_1 = profile_1;
        }

        public string UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Profile_1 { get; set; }
    }
}