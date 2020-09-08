using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using news_feed.Data;
using news_feed.Domain;

namespace news_feed.Controllers
{
    public class NewsFeedsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewsFeedsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NewsFeeds
        public async Task<IActionResult> Index()
        {
            return View(await _context.NewsFeed.Include(x => x.News).ToListAsync().ConfigureAwait(false));
        }

        // GET: NewsFeeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsFeed = await _context.NewsFeed
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newsFeed == null)
            {
                return NotFound();
            }

            return View(newsFeed);
        }

        // GET: NewsFeeds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewsFeeds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] NewsFeed newsFeed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newsFeed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newsFeed);
        }

        // GET: NewsFeeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsFeed = await _context.NewsFeed.FindAsync(id);
            if (newsFeed == null)
            {
                return NotFound();
            }
            return View(newsFeed);
        }

        // POST: NewsFeeds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] NewsFeed newsFeed)
        {
            if (id != newsFeed.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsFeed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsFeedExists(newsFeed.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(newsFeed);
        }

        // GET: NewsFeeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsFeed = await _context.NewsFeed
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newsFeed == null)
            {
                return NotFound();
            }

            return View(newsFeed);
        }

        // POST: NewsFeeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newsFeed = await _context.NewsFeed.FindAsync(id);
            _context.NewsFeed.Remove(newsFeed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsFeedExists(int id)
        {
            return _context.NewsFeed.Any(e => e.Id == id);
        }
    }
}
