using MyApp.Areas.Admin;
using MyApp.Models.Portfolio;
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

        public ActionResult Test()
        {
            return View();
        }
    }
}