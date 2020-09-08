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

        // GET: News
        public async Task<IActionResult> Index()
        {
            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);

            var viewModel = new NewsViewModel
            {
                //News = await _context.News.Include(x => x.NewsFeed).ToListAsync(),
                News = await _newsService.GetAll().ConfigureAwait(false),
                User = await _userManager.GetUserAsync(User)
            };

            return View(viewModel);
        }

        // GET: News/Details/5
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

        //// GET: News/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: News/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Title,Content,Timestamp")] News news)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(news);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(news);
        //}

        //// GET: News/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var news = await _context.News.FindAsync(id);
        //    if (news == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(news);
        //}

        //// POST: News/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,Timestamp")] News news)
        //{
        //    if (id != news.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(news);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!NewsExists(news.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(news);
        //}

        //// GET: News/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var news = await _context.News
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (news == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(news);
        //}

        //// POST: News/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var news = await _context.News.FindAsync(id);
        //    _context.News.Remove(news);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool NewsExists(int id)
        //{
        //    return _context.News.Any(e => e.Id == id);
        //}
    }
}
