using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Repository.Models
{
    public class RegisterTextRequest
    {
        public RegisterTextRequest(string userId, string title, string description, string profile_1)
        {
            UserId = userId;
            Title = title;
            Description = description;
            Profile_1 = profile_1;
        }

        public string UserId { get; }

        public string Title { get; }

        public string Description { get; }

        public string Profile_1 { get; }
    }
}