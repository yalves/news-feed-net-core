using news_feed.Domain;
using System.Collections.Generic;

namespace news_feed.Services
{
    public interface ISubscriptionService
    {
        public IEnumerable<NewsFeed> GetUserSubscriptions(string UserId);
    }
}
