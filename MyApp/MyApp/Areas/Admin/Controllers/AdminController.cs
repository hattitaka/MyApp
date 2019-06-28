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

        // 「3.1 編集内容の保存アクションを作成する.txt」
        /* --------------------------------------------------------------------------------- */

        /* --------------------------------------------------------------------------------- */

        /// <summary>
        /// ブラウザが「～/Admin/Edit」にアクセスしたときに呼び出される
        /// </summary>
        /// <param name="model">EditPageViewModelクラスを引数として受け付けています</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(EditPageViewModel model)
        {
            // 画面から送られてきたクラス(EditPageViewModel model)から各値を抜き出す
            var id = userId;
            var title = model.Title;
            var description = model.Description;
            var profiles = model.Profiles;

            // 保存のためのリクエストクラスを作成
            var request = new ChangeContentRequest(id, title, description, profiles);

            // 保存メソッド実行
            var result = contentRepository.ChengeContent(request);

            // エラーだった時の処理
            if (result.HasError)
            {
                model.ExecuteResultMessage = result.ErrorMessage;
                return View(model);
            }

            // 変更通知
            model.ExecuteResultMessage = "変更しました";

            // 変更結果を返す
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