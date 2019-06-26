using MyApp.Areas.Admin.Models;
using MyApp.Areas.Admin.Models.UserCase.ChangeUserInfo;
using MyApp.Areas.Admin.Models.UserCase.GetUserDetails;
using MyApp.Areas.Admin.Models.ViewModel.User;
using System.Web.Mvc;

namespace MyApp.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        [HttpGet]
        public ActionResult UserDetails()
        {
            var request = new GetUserDetailsRequest(userId);
            var response = userData.GetUserDetails(request);
            return View("UserDetails", new UserDetailsPageViewModel(response.LoginId, response.Name, response.MailAddress));
        }

        [HttpGet]
        public ActionResult Settings()
        {
            var request = new GetUserDetailsRequest(userId);
            var response = userData.GetUserDetails(request);

            var viewModel = new SettingPageViewModel()
            {
                Password = response.Password,
                Name = response.Name,
                MailAddress = response.MailAddress
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Settings(SettingPageViewModel viewModel)
        {
            var request = new ChangeUserInfoRequest(userId, viewModel.Name, viewModel.MailAddress, viewModel.Password);
            var response = userData.ChangeUserInfo(request);

            return RedirectToAction("UserDetails");
        }
    }
}