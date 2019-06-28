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

        // 「HelloWorld的なことをしてみる.txt」
        /* --------------------------------------------------------------- */
        
        /* --------------------------------------------------------------- */

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