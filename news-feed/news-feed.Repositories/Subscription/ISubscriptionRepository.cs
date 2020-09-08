using news_feed.Domain;
using System;
using System.Collections.Generic;

namespace news_feed.Repositories
{
    public interface ISubscriptionRepository
    {
        IEnumerable<NewsFeed> GetByUserId(string userId);
    }
}
