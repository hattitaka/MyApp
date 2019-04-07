using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.InMemoryInfrastructure.Models
{
    public class GetTextResponse
    {
        public GetTextResponse(string title, string description, string profile_1)
        {
            Title = title;
            Description = description;
            Profile_1 = profile_1;
        }

        public GetTextResponse() { }

        public string Title { get; }

        public string Description { get; }

        public string Profile_1 { get; }
    }
}