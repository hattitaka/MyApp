using MyApp.Areas.Admin.Models;
using MyApp.Areas.Admin.Models.UserCase.ChangeContent;
using MyApp.Areas.Admin.Models.UserCase.GetContent;
using System.Web.Mvc;

namespace MyApp.Areas.Admin.Controllers
{
    [HandleError]
    public class AdminController : BaseController
    {
        [HttpGet]
        public ActionResult Edit()
        {
            var text = contentData.GetContent(new GetContentRequest(userId));
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
            var result = contentData.ChengeContent(request);

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
            var response = contentData.GetContent(request);

            return PartialView("_PreviewPartial" ,new PreviewPartialViewModel(response.Title, response.Description, response.Profiles));
        }
    }
}