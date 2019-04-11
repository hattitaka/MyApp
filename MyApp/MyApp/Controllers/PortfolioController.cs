using MyApp.Areas.Admin.Controllers;
using MyApp.Models.Portfolio;
using System.Linq;
using System.Web.Mvc;
using static MyApp.Models.Portfolio.GetPageListViewModel;

namespace MyApp.Controllers
{
    public class PortfolioController : BaseController
    {
        [HttpGet]
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