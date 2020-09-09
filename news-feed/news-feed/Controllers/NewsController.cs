using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using news_feed.Domain;
using news_feed.Services;
using news_feed.ViewModels;

namespace news_feed.Controllers
{
    [Authorize]
    public class NewsController : Controller
    {        
        private readonly INewsService _newsService;

        private readonly UserManager<ApplicationUser> _userManager;


        public NewsController(INewsService newsService, UserManager<ApplicationUser> userManager)
        {
            _newsService = newsService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = _userManager.Users.Include(x => x.SubscribedFeeds).FirstOrDefault(x => x.Id == _userManager.GetUserId(User));

            var viewModel = new NewsViewModel
            {
                News = await _newsService.GetAll().ConfigureAwait(false),
                User = user
            };

            return View(viewModel);
        }

        [HttpGet("MyNews")]
        public async Task<IActionResult> MyNews()
        {
            var user = _userManager.Users.Include(x => x.SubscribedFeeds).FirstOrDefault(x => x.Id == _userManager.GetUserId(User));

            var userFeedIds = user.SubscribedFeeds.Select(x => x.NewsFeedId).ToList();
            var userNews = await _newsService.GetByNewsFeedIds(userFeedIds).ConfigureAwait(false);

            var viewModel = new NewsViewModel
            {
                News = userNews,
                User = user
            };

            return View("MyNews", viewModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _newsService.GetById(id).ConfigureAwait(false);

            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }
    }
}
