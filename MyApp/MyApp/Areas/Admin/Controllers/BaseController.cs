using MyApp.Areas.Admin.Models.Repository;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyApp.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public string userName { get; set; }

        public string userId { get; set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            userName = requestContext.HttpContext.Session["username"]?.ToString();

            userId = requestContext.HttpContext.Session["userid"]?.ToString();

            return base.BeginExecute(requestContext, callback, state);
        }

        /// <summary>
        /// 各アクションが実行される直前にここの処理が走ります
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // ログインの必要がないページのパス
            string[] NO_CHECK_PATH = { "/", "/Admin/Auth/Login", "/Portfolio/GetPageList" };

            // 現在のパスがNO_CHECK_PATHに含まれているならreturn
            if (NO_CHECK_PATH.Contains(filterContext.HttpContext.Request.Path)) { return; }

            // セッションにユーザーIDが入っていない(ログインを行っていない)ならトップページに飛ばす
            if (Session["userid"] == null)
            {
                // セッション値を初期化
                filterContext.HttpContext.Session.RemoveAll();

                filterContext.Result = new RedirectResult("~/");
                return;
            }

            base.OnActionExecuting(filterContext);
        }

    }
}