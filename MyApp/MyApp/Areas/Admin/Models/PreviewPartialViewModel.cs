﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Models
{
    public class PreviewPartialViewModel
    {
        public PreviewPartialViewModel(string title, string description, string profiles)
        {
            Title = title;
            Description = description;
            Profiles = profiles;
        }

        public string Title { get; }

        public string Description { get; }

        public string Profiles { get; }
    }
}