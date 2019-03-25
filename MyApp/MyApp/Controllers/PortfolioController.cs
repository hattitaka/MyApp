using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApp.Controllers
{
    public class PortfolioController : Controller
    {
        // GET: Portfolio
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}