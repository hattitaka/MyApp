using MyApp.Areas.Admin.Models;
using MyApp.Areas.Admin.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApp.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        public ActionResult UserDetails()
        {
            var response = userData.GetUserDetails(userId);
            return View("UserDetails", new UserDetailsPageViewModel(response.LoginId, response.Name, response.Address));
        }

        public ActionResult Settings()
        {
            var response = userData.GetUserDetails(userId);
            return View(new UserSettingPageViewModel(response.LoginId, response.Name, response.Address));
        }

        public ActionResult SaveChange(SaveUserChangeRequestModel request)
        {
            var req = new SaveUserChangeRequest(userId, request.LoginId, request.Name, request.Address);

            userData.SaveChange(req);

            return RedirectToAction("UserDetails");
        }
    }
}