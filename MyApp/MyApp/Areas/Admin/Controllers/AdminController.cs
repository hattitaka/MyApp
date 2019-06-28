using MyApp.Areas.Admin.Models;
using MyApp.Areas.Admin.Models.Repository;
using MyApp.Areas.Admin.Models.UserCase.ChangeContent;
using MyApp.Areas.Admin.Models.UserCase.GetContent;
using System.Web.Mvc;

namespace MyApp.Areas.Admin.Controllers
{
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

        // 「3.1 編集内容の保存アクションを作成する.txt」
        /* --------------------------------------------------------------------------------- */
        
        /* --------------------------------------------------------------------------------- */

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