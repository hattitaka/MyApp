using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Repository.Models
{
    public class SaveChangeRequest
    {

        public string Title { get; set; }

        public string Description { get; set; }

        public string Profile_1 { get; set; }
    }
}