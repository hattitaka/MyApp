using MyApp.Areas.Admin.Common;
using MyApp.Areas.Admin.Models;
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
        public ActionResult Login(LoginRequestModel user)
        {
            bool isNullUser = userData.CheckUser(new User(user.Id, user.Name));
            if (!isNullUser)
            {
                return RedirectToAction("Index", "Auth");
            }

            string token = LoginToken.GetToken();
            HttpCookie tokenCookie = new HttpCookie("token", token)
            {
                Secure = Convert.ToBoolean(WebConfigurationManager.AppSettings["CookieSecure"]),
                HttpOnly = true
            };
            Response.Cookies.Add(tokenCookie);

            Session["token"] = token;
            Session["userid"] = user.Id;
            Session["username"] = user.Name;

            return RedirectToAction("Edit", "Admin");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            // Cookie削除
            Response.Cookies["token"].Expires = DateTime.Now.AddDays(-1);

            Session.Abandon();

            return RedirectToAction("Index", "Portfolio", new { area = "" });
        }
    }
}