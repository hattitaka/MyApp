using MyApp.Areas.Admin.Models;
using MyApp.Areas.Admin.Repository.Models;
using System;
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
            // ユーザーの存在チェック
            var response = userData.CheckUser(new CheckUserRequest(request.LoginId, request.Password));

            // 存在しなければログイン画面に戻す
            if (response == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            // 存在していればセッションにユーザーIDを保存
            Session["userid"] = response.Id;

            return RedirectToAction("Edit", "Home");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            // Session削除
            Session.Abandon();

            return RedirectToAction("Index", "Portfolio", new { area = "" });
        }
    }
}