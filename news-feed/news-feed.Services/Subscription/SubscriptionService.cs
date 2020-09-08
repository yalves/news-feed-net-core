using news_feed.Domain;
using news_feed.Repositories;
using System;
using System.Collections.Generic;

namespace news_feed.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public IEnumerable<NewsFeed> GetUserSubscriptions(string UserId)
        {
            throw new NotImplementedException();
        }
    }
}
