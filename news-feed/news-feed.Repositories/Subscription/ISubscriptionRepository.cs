using news_feed.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace news_feed.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Domain.NewsFeed>> GetByUserId(string userId);
    }
}
