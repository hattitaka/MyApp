using MyApp.Areas.Admin.Models;
using MyApp.Areas.Admin.Repository.Models;
using System.Web.Mvc;

namespace MyApp.Areas.Admin.Controllers
{
    [HandleError]
    public class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult Edit()
        {
            var text = textData.GetText(userId);
            var model = new EditPageViewModel()
            {
                Title = text.Title,
                Description = text.Description,
                Profile_1 = text.Profile_1
            };
            return View(model);
        }
        // 「3.1 編集内容の保存アクションを作成する.txt」の中身をこの間にコピー
        /* --------------------- */
        
        /* --------------------- */

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