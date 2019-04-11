using MyApp.Areas.Admin.Repository;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyApp.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // テスト用
        public InMemoryUserRepositories userData { get; }
        public InMemoryPortfolioWordRepositories textData { get; }

        // DB接続用
        // public UserRepository userData { get; }
        // public TextRepository textData { get; }

        public string userName { get; set; }

        public string userId { get; set; }

        public BaseController()
        {
            // テスト用
            userData = new InMemoryUserRepositories();
            textData = new InMemoryPortfolioWordRepositories();

            // DB接続用
            // userData = new UserRepository();
            // textData = new TextRepository();
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            userId = requestContext.HttpContext.Session["userid"]?.ToString();

            return base.BeginExecute(requestContext, callback, state);
        }

        /// <summary>
        /// アクションが呼び出される前に実行される
        /// セッションに値が存在しなければログインしていないユーザーと判断し
        /// ログイン画面へ飛ばす
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // アクセスがNO_CHECK_PATHに含まれるものだった時はログインチェックをしない
            // 例：ログイン画面へ来た場合はログインチェックは必要ない
            string[] NO_CHECK_PATH = { "/", "/Admin/Auth/Login", "/Portfolio/GetPageList" };
            if (NO_CHECK_PATH.Contains(filterContext.HttpContext.Request.Path)) { return; }

            if (Session["userid"] == null)
            {
                // セッション値を初期化
                filterContext.HttpContext.Session.RemoveAll();

                // ログイン画面へ飛ばす
                filterContext.Result = new RedirectResult("~/Admin/Auth/Login");
                return;
            }

            base.OnActionExecuting(filterContext);
        }

    }
}