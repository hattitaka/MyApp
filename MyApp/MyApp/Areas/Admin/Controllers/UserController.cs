﻿using MyApp.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApp.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        InMemoryUserRepositories data = new InMemoryUserRepositories();

        public ActionResult UserDetails()
        {
            var response = data.GetUserDetails("test");
            return View("UserDetails", new UserDetailsPageViewModel(response.Id, response.LoginId, response.Name, response.MailAddress));
        }

        public ActionResult Settings()
        {
            var response = data.GetUserDetails("test");
            return View(new UserSettingPageViewModel(response.Id, response.LoginId, response.Name, response.MailAddress));
        }
    }
}