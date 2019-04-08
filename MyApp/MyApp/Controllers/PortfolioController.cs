using MyApp.Areas.Admin;
using MyApp.Areas.Admin.Controllers;
using MyApp.Models.Portfolio;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using static MyApp.Models.Portfolio.GetPageListViewModel;

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
            var userList = userData.GetUserList().UserList
                .Select(x => new DisplayUserItem(x.Id, x.Name))
                .ToList();

            var response = new GetPageListViewModel()
            {
                UserList = userList
            };
            return View(response);
        }
    }
}