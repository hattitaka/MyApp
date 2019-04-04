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

        //public UserRepository userData = new UserRepository();

        public BaseController()
        {
            userData = new InMemoryUserRepositories();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string[] NO_CHECK_PATH = { "/", "/Admin/Auth/Login" };

            if (NO_CHECK_PATH.Contains(filterContext.HttpContext.Request.Path)) { return; }

            base.OnActionExecuting(filterContext);
        }
    }
}