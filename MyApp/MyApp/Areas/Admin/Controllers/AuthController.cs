using MyApp.Areas.Admin.Models;
using MyApp.Areas.Admin.Models.Repository;
using MyApp.Areas.Admin.Models.UserCase.CheckUser;
using System;
using System.Web.Mvc;

namespace MyApp.Areas.Admin.Controllers
{
    public class AuthController : BaseController
    {
        private IContentRepository contentRepository;

        private IUserRepository userRepository;

        public AuthController(IUserRepository userRepository, IContentRepository contentRepository)
        {
            this.userRepository = userRepository;
            this.contentRepository = contentRepository;
        }

        // GET: Admin/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginRequestModel viewModel)
        {
            // ユーザーの存在チェック
            var request = new CheckUserRequest(viewModel.LoginId, viewModel.Password);
            var response = userRepository.CheckUser(request);

            // 存在しなければログイン画面に戻す
            if (response == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            // セッションでUserIdを保存する
            /*---------------------------------------------*/
            Session["userid"] = response.Id;
            /*---------------------------------------------*/

            return RedirectToAction("Edit", "Admin");
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