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
            var model = new EditPageViewModel(text.Title, text.Description, text.Profile_1);
            return View(model);
        }

        /// <summary>
        /// ブラウザが「～～/Admin/Edit」にアクセスしたときに呼び出される
        /// </summary>
        /// <param name="request">EditPageViewModel</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(EditPageViewModel request)
        {
            // どこで作られるかは秘密
            var id = userId;

            // 画面からきたリクエストたちをtitle, description, profile_1に
            var title = request.Title;
            var description = request.Description;
            var profile_1 = request.Profile_1;

            // 保存メソッドに渡すためのリクエストクラスを作る
            var saveData = new RegisterTextRequest(id, title, description, profile_1);

            // saveDataを保存メソッドに渡す
            textData.SaveText(saveData);

            // プレビューアクションを呼び出す
            return View();
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