using Microsoft.EntityFrameworkCore;
using news_feed.Repositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace news_feed.Repositories.NewsFeed
{
    public class NewsFeedRepository : INewsFeedRepository
    {
        private readonly ApplicationDbContext _context;

        public NewsFeedRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.NewsFeed> GetById(int id)
        {
            return await _context.NewsFeed.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
