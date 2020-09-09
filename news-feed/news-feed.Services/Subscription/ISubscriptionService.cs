using news_feed.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace news_feed.Services
{
    public interface ISubscriptionService
    {
        //public Task<IEnumerable<NewsFeed>> GetUserSubscriptions(string UserId);
        public Task Subscribe(ApplicationUser user, int newsFeedId);
        public Task Unsubscribe(ApplicationUser user, int newsFeedId);
    }
}
