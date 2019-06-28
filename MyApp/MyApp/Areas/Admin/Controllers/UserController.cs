using MyApp.Areas.Admin.Models;
using MyApp.Areas.Admin.Models.Repository;
using MyApp.Areas.Admin.Models.UserCase.ChangeUserInfo;
using MyApp.Areas.Admin.Models.UserCase.CreateUser;
using MyApp.Areas.Admin.Models.UserCase.GetUserDetails;
using MyApp.Areas.Admin.Models.ViewModel.User;
using System.Web.Mvc;

namespace MyApp.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private IContentRepository contentRepository;

        private IUserRepository userRepository;

        public UserController(IUserRepository userRepository, IContentRepository contentRepository)
        {
            this.userRepository = userRepository;
            this.contentRepository = contentRepository;
        }

        [HttpGet]
        public ActionResult UserDetails()
        {
            var request = new GetUserDetailsRequest(userId);
            var response = userRepository.GetUserDetails(request);
            return View("UserDetails", new UserDetailsPageViewModel(response.LoginId, response.Name, response.MailAddress));
        }

        [HttpGet]
        public ActionResult Settings()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Settings(SettingPageViewModel viewModel)
        {
            return View();
        }
    }
}