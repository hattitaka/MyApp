﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Models
{
    public class LoginRequestModel
    {
        public string LoginId { get; set; }

        public string Password { get; set; }
    }
}