using news_feed.Domain;
using news_feed.Repositories;
using news_feed.Repositories.News;
using news_feed.Repositories.NewsFeed;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace news_feed.Services
{
    public class NewsFeedService : INewsFeedService
    {
        private readonly INewsFeedRepository _newsFeedRepository;
        public NewsFeedService(INewsFeedRepository newsFeedRepository)
        {
            _newsFeedRepository = newsFeedRepository;
        }

        public async Task<NewsFeed> GetById(int id)
        {
            return await _newsFeedRepository.GetById(id).ConfigureAwait(false);
        }
    }
}
