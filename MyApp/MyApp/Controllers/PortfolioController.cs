using MyApp.Areas.Admin;
using MyApp.Areas.Admin.Controllers;
using MyApp.Models.Portfolio;
using System.Web.Mvc;

namespace MyApp.Controllers
{
    public class PortfolioController : BaseController
    {
        // GET: Portfolio
        [HttpGet]
        public ActionResult Index(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("GetPageList");
            }

            var text = textData.GetText(userId);

            return View(new IndexViewModel(text.Title, text.Description, text.Profile_1));
        }

        public ActionResult GetPageList()
        {
            var response = new GetPageListViewModel()
            {
                UserIdList = userData.GetUserIdList().UserIdList,
            };
            return View(response);
        }
    }
}