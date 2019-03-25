using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Models.Portfolio
{
    public class EditViewModel
    {
        public EditViewModel(string title, string description, string profile_1, string profile_2)
        {
            Title = title;
            Description = description;
            Profile_1 = profile_1;
            Profile_2 = profile_2;
        }

        public string Title { get; }

        public string Description { get; }

        public string Profile_1 { get; }

        public string Profile_2 { get; }
    }
}