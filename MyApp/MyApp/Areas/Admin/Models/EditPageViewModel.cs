﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Models
{
    public class EditPageViewModel
    {
        public EditPageViewModel(string title, string description, string profile_1)
        {
            Title = title;
            Description = description;
            Profile_1 = profile_1;
        }

        public string Title { get; }

        public string Description { get; }

        public string Profile_1 { get; }
    }
}