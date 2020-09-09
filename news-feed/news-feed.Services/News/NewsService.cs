using news_feed.Domain;
using news_feed.Repositories.News;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace news_feed.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;
        public NewsService(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<IEnumerable<News>> GetAll()
        {
            return await _newsRepository.GetAll().ConfigureAwait(false);
        }

        public async Task<News> GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return await _newsRepository.GetById((int)id);
        }

        public async Task<IEnumerable<News>> GetByNewsFeedIds(IEnumerable<int> userFeedIds)
        {
            return await _newsRepository.GetByNewsFeedIds(userFeedIds).ConfigureAwait(false);
        }
    }
}
