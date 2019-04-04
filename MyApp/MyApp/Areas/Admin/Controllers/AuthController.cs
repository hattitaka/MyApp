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
            // 存在するユーザーかチェック
            bool isNullUser = userData.CheckUser(user.Id, user.Address);

            // 存在しなければログイン画面へ
            if (!isNullUser)
            {
                return RedirectToAction("Login", "Auth");
            }

            // 存在すればセッションに保存
            Session["userid"] = user.Id;
            Session["mailaddress"] = user.Address;

            return RedirectToAction("Edit", "Admin");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            // Cookie削除
            Response.Cookies["userid"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["mailaddress"].Expires = DateTime.Now.AddDays(-1);

            Session.Abandon();

            return RedirectToAction("Index", "Portfolio", new { area = "" });
        }
    }
}