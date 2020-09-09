using Microsoft.AspNetCore.Identity;
using news_feed.Domain;
using news_feed.Repositories;
using news_feed.Repositories.NewsFeed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace news_feed.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly INewsFeedRepository _newsFeedRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public SubscriptionService(NewsFeedRepository newsFeedRepository, UserManager<ApplicationUser> userManager)
        {
            _newsFeedRepository = newsFeedRepository;
            _userManager = userManager;
        }

        public async Task Subscribe(ApplicationUser user, int newsFeedId)
        {
            var newsFeed = await _newsFeedRepository.GetById(newsFeedId).ConfigureAwait(false);

            var subscription = new UserNewsFeed
            {
                NewsFeed = newsFeed,
                NewsFeedId = newsFeedId,
                User = user,
                UserId = user.Id
            };

            if (user.SubscribedFeeds == null)
            {
                user.SubscribedFeeds = new List<UserNewsFeed>
                {
                    subscription
                };
            }
            else
            {
                user.SubscribedFeeds.Add(subscription);
            }

            await _userManager.UpdateAsync(user).ConfigureAwait(false);
        }

        public async Task Unsubscribe(ApplicationUser user, int newsFeedId)
        {
            if (user.SubscribedFeeds == null)
                return;

            user.SubscribedFeeds = user.SubscribedFeeds.Where(x => x.NewsFeedId != newsFeedId).ToList();

            await _userManager.UpdateAsync(user).ConfigureAwait(false);
        }
    }
}
