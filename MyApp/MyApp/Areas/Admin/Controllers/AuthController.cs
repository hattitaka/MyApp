using MyApp.Areas.Admin.Common;
using MyApp.Areas.Admin.Repository.Models;
using MyApp.Areas.Admin.Models;
using MyApp.Areas.Admin.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace MyApp.Areas.Admin.Controllers
{
    public class AuthController : BaseController
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginRequestModel request)
        {
            var response = userData.CheckUser(new CheckUserRequest(request.LoginId, request.Address));
            if (String.IsNullOrEmpty(response.Id))
            {
                return RedirectToAction("Login", "Auth");
            }

            Session["userid"] = response.Id;

            return RedirectToAction("Edit", "Admin");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            // Cookie削除
            Response.Cookies["userid"].Expires = DateTime.Now.AddDays(-1);
            Session.Abandon();

            return RedirectToAction("Index", "Portfolio", new { area = "" });
        }
    }
}