using MyApp.Areas.Admin.Controllers;
using MyApp.Areas.Admin.Models.Repository;
using MyApp.Areas.Admin.Models.UserCase.GetContent;
using MyApp.Models.Portfolio;
using System.Linq;
using System.Web.Mvc;

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

        /// <summary>
        /// ブラウザが「～/Portfolio/Index」にアクセスしたときに呼び出される
        /// </summary>
        /// <returns>/Views/Portfolio/Index.cshtmlをブラウザに返す</returns>
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
                .Select(x => new GetPageListViewModel.DisplayUserItem(x.Id, x.Name))
                .ToList();

            var response = new GetPageListViewModel()
            {
                UserList = userList
            };
            
            return View(response);
        }
    }
}