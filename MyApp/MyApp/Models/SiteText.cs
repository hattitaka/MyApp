using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Models
{
    public class SiteText
    {
        public SiteText(string id, string text)
        {
            Id = id;
            Text = text;
        }

        public string Id { get; }

        public string Text { get; }
    }
}