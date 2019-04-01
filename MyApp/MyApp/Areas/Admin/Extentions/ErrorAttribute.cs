using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApp.Areas.Admin.Extentions
{
    public class ErrorAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if(filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            filterContext.Result = new RedirectResult("~/Admin/Error/Error");
            return;
        }
    }
}