using MyApp.Areas.Admin.Models;
using MyApp.Areas.Admin.Repository.Models;
using System.Web.Mvc;

namespace MyApp.Areas.Admin.Controllers
{
    [HandleError]
    public class AdminController : BaseController
    {
        public ActionResult Edit()
        {
            var text = textData.GetText(userId);
            var model = new EditPageViewModel(text.Title, text.Description, text.Profile_1);
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
            var text = textData.GetText(userId);

            return PartialView("_PreviewPartial" ,new PreviewPartialViewModel(text.Title, text.Description, text.Profile_1));
        }
    }
}