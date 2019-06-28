using MyApp.Areas.Admin.Models;
using MyApp.Areas.Admin.Models.Repository;
using MyApp.Areas.Admin.Models.UserCase.ChangeContent;
using MyApp.Areas.Admin.Models.UserCase.GetContent;
using System.Web.Mvc;

namespace MyApp.Areas.Admin.Controllers
{
    [HandleError]
    public class AdminController : BaseController
    {
        private IContentRepository contentRepository;

        private IUserRepository userRepository;

        public AdminController(IUserRepository userRepository, IContentRepository contentRepository)
        {
            this.userRepository = userRepository;
            this.contentRepository = contentRepository;
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var text = contentRepository.GetContent(new GetContentRequest(userId));
            var model = new EditPageViewModel()
            {
                Title = text.Title,
                Description = text.Description,
                Profiles = text.Profiles,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditPageViewModel model)
        {
            var request = new ChangeContentRequest(userId, model.Title, model.Description, model.Profiles);
            var result = contentRepository.ChengeContent(request);

            if (result.HasError)
            {
                model.ExecuteResultMessage = result.ErrorMessage;
                return View(model);
            }

            model.ExecuteResultMessage = "変更しました";
            return View(model);
        }

        [HttpGet]
        public ActionResult Preview()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult GetPreviewPage()
        {
            var request = new GetContentRequest(userId);
            var response = contentRepository.GetContent(request);

            return PartialView("_PreviewPartial" ,new PreviewPartialViewModel(response.Title, response.Description, response.Profiles));
        }
    }
}