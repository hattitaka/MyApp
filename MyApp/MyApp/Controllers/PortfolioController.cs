using MyApp.Areas.Admin;
using MyApp.Areas.Admin.Controllers;
using MyApp.Models.Portfolio;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using static MyApp.Models.Portfolio.GetPageListViewModel;
using MyApp.Areas.Admin.Models.UserCase.GetContent;
using MyApp.Areas.Admin.Models.Models;
using MyApp.Areas.Admin.Models.Repository;

namespace MyApp.Controllers
{
    public class PortfolioController : BaseController
    {
        private IContentRepository contentRepository;

        private IUserRepository userRepository;

        public PortfolioController(IUserRepository userRepository, IContentRepository contentRepository)
        {
            this.userRepository = userRepository;
            this.contentRepository = contentRepository;
        }

        // GET: Portfolio
        [HttpGet]
        public ActionResult Index(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("GetPageList");
            }

            var request = new GetContentRequest(userId);
            var response = contentRepository.GetContent(request);

            return View(new IndexViewModel(response.Title, response.Description, response.Profiles));
        }

        [HttpGet]
        public ActionResult GetPageList()
        {
            var userList = userRepository.GetUserSummaries().Summaries
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