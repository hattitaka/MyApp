using MyApp.Areas.Admin.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Models.UserCase.ChangeContent
{
    public class ChangeContentRequest
    {
        public ChangeContentRequest(string userId, string title, string description, string profiles)
        {
            UserId = userId;
            Title = title;
            Description = description;
            Profiles = profiles;
        }

        public string UserId { get; }

        public string Title { get; }

        public string Description { get; }

        public string Profiles { get; }
    }
}