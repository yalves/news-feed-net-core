using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using news_feed.Data;
using news_feed.Domain;
using news_feed.Services;
using news_feed.ViewModels;

namespace news_feed.Controllers
{
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
            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);

            var viewModel = new NewsViewModel
            {
                News = await _newsService.GetAll().ConfigureAwait(false),
                User = await _userManager.GetUserAsync(User)
            };

            return View(viewModel);
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
