using Microsoft.EntityFrameworkCore;
using news_feed.Domain;
using news_feed.Repositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace news_feed.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly ApplicationDbContext _context;

        public SubscriptionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Domain.NewsFeed>> GetByUserId(string userId)
        {
            return await _context.UserNewsFeed.Where(x => x.UserId == userId)
                                              .Select(x => x.NewsFeed)
                                              .ToListAsync().ConfigureAwait(false);
        }
    }
}
