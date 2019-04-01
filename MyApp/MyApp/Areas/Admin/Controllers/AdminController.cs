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
    public class AdminController : BaseController
    {
        InMemoryPortfolioWordRepositories data = new InMemoryPortfolioWordRepositories();
        
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit()
        {
            var text = data.GetAll();
            var model = new EditPageViewModel(text.Title, text.Description, text.Profile_1, text.Profile_2);
            return View(model);
        }

        [Error]
        public ActionResult SaveChange(SaveChangeRequest request)
        {
            data.SaveAll(new AllText(request.Title, request.Description, request.Profile_1, request.Profile_2));
            
            return Redirect("Index");
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

            return PartialView("_PreviewPartial" ,new PreviewPartialViewModel(text.Title, text.Description, text.Profile_1, text.Profile_2));
        }
    }
}