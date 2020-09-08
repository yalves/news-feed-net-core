using Microsoft.EntityFrameworkCore;
using news_feed.Repositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace news_feed.Repositories.News
{
    public class NewsRepository : INewsRepository
    {
        private readonly ApplicationDbContext _context;

        public NewsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.News>> GetAll()
        {
            return await _context.News.Include(x => x.NewsFeed).ToListAsync();
        }

        public async Task<Domain.News> GetById(int id)
        {
            return await _context.News.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
