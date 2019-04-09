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