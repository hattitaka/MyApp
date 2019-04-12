using MyApp.Areas.Admin.Controllers;
using MyApp.Models.Portfolio;
using System.Linq;
using System.Web.Mvc;
using static MyApp.Models.Portfolio.GetPageListViewModel;

namespace MyApp.Controllers
{
    public class PortfolioController : BaseController
    {
        [HttpGet]
        public ActionResult GetPageList()
        {
            var userList = userData.GetUserList().UserList
                .Select(x => new DisplayUserItem(x.Id, x.Name))
                .ToList();

            var response = new GetPageListViewModel()
            {
                UserList = userList
            };
            return View(response);
        }

        // GET: Portfolio
        [HttpGet]
        public ActionResult Index(string userId)
        {
            // useridの空白とNullのチェック
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("GetPageList");
            }

            // DBからデータを取得
            var text = textData.GetText(userId);

            // 画面で受け取るデータのクラス
            var response = new IndexViewModel(text.Title, text.Description, text.Profile_1);

            // Views/Portfolio/Index.cshtmlをブラウザに返す
            return View(response);
        }
    }
}