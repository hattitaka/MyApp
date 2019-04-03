using MyApp.Areas.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyApp.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public InMemoryUserRepositories userData { get; set; }

        public string userName { get; set; }

        public string userId { get; set; }

        public BaseController()
        {
            userData = new InMemoryUserRepositories();
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.userName = requestContext.HttpContext.Session["username"]?.ToString();

            this.userId = requestContext.HttpContext.Session["userid"]?.ToString();

            return base.BeginExecute(requestContext, callback, state);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string[] NO_CHECK_PATH = { "/", "/Admin/Auth/Login" };

            if (NO_CHECK_PATH.Contains(filterContext.HttpContext.Request.Path)) { return; }

            string token = ValueProvider.GetValue("token").AttemptedValue;
            if (token == null ||
                token != filterContext.HttpContext.Request.Cookies["token"].Value)
            {
                // セッション値を初期化
                filterContext.HttpContext.Session.RemoveAll();

                filterContext.Result = new RedirectResult("~/Admin/Auth/Login");
                return;
            }

            base.OnActionExecuting(filterContext);
        }

    }
}