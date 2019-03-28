using MyApp.Common;
using MyApp.InMemoryInfrastructure;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace MyApp.Areas.Admin.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(User user)
        {
            bool isNullUser = userData.CheckUser(user);
            if (!isNullUser)
            {
                return Redirect("Index");
            }

            string token = LoginToken.GetToken();
            HttpCookie tokenCookie = new HttpCookie("token", token);
            tokenCookie.Secure = Convert.ToBoolean(WebConfigurationManager.AppSettings["CookieSecure"]);
            tokenCookie.HttpOnly = true;
            Response.Cookies.Add(tokenCookie);

            Session["token"] = token;
            Session["userid"] = user.Id;
            Session["username"] = user.Name;

            return RedirectToAction("Index", "Portfolio");
        }
    }
}