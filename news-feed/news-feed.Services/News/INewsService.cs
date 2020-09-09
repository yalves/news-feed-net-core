using news_feed.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace news_feed.Services
{
    public interface INewsService
    {
        Task<IEnumerable<News>> GetAll();
        Task<News> GetById(int? id);
        Task<IEnumerable<News>> GetByNewsFeedIds(IEnumerable<int> userFeedIds);
    }
}
