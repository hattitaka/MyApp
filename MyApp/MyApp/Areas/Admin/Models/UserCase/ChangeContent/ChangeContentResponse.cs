using MyApp.Areas.Admin.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Models.UserCase.ChangeContent
{
    public class ChangeContentResponse: ResponseBase
    {
        public ChangeContentResponse(string title, string description, string profiles)
        {
            Title = title;
            Description = description;
            Profiles = profiles;
        }

        public ChangeContentResponse(string errorMessage) : base(errorMessage) { }

        public string Title { get; }

        public string Description { get; }

        public string Profiles { get; }
    }
}