using MyApp.InMemoryInfrastructure;
using MyApp.Models;
using MyApp.Models.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApp.Controllers
{
    public class PortfolioController : Controller
    {
        InMemoryPortfolioWordRepositories data = new InMemoryPortfolioWordRepositories();

        // GET: Portfolio
        [HttpGet]
        public ActionResult Index()
        {
            var text = data.GetAll();

            return View(new IndexViewModel(text.Title, text.Description, text.Profile_1, text.Profile_2));
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var text = data.GetAll();

            return View(new EditViewModel(text.Title, text.Description, text.Profile_1, text.Profile_2));
        }

        [HttpPost]
        public ActionResult Edit(EditRequestModel request)
        {
            data.SaveAll(new AllText(request.Title, request.Description, request.Profile_1, request.Profile_2));

            return Redirect("Index");
        }
    }
}