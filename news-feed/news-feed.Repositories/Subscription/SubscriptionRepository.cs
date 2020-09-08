using news_feed.Domain;
using news_feed.Repositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace news_feed.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly ApplicationDbContext _context;

        public SubscriptionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<NewsFeed> GetByUserId(string userId)
        {
            return _context.UserNewsFeed.Where(x => x.UserId == userId)
                                        .Select(x => x.NewsFeed)
                                        .ToList();
        }
    }
}
