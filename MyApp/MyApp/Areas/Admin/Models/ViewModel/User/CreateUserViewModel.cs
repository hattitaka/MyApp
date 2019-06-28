using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Models.ViewModel.User
{
    public class CreateUserViewModel
    {
        public string Name { get; set; }

        public string LoginId { get; set; }

        public string Password { get; set; }

        public string MailAddress { get; set; }
    }
}