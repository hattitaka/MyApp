using MyApp.Areas.Admin.Extentions;
using MyApp.Areas.Admin.Models;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApp.Areas.Admin.Controllers
{
    [HandleError]
    public class AdminController : BaseController
    {
        InMemoryPortfolioWordRepositories data = new InMemoryPortfolioWordRepositories();

        public ActionResult Edit()
        {
            var text = data.GetAll();
            var model = new EditPageViewModel(text.Title, text.Description, text.Profile_1);
            return View(model);
        }

        public ActionResult SaveChange(SaveChangeRequest request)
        {
            data.SaveAll(new AllText(request.Title, request.Description, request.Profile_1));
            
            return Redirect("Preview");
        }

        [HttpGet]
        public ActionResult Preview()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult GetPreviewPage()
        {
            var text = data.GetAll();

            return PartialView("_PreviewPartial" ,new PreviewPartialViewModel(text.Title, text.Description, text.Profile_1));
        }
    }
}