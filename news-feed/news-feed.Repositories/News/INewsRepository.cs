using System.Collections.Generic;
using System.Threading.Tasks;
using news_feed.Domain;

namespace news_feed.Repositories.News
{
    public interface INewsRepository
    {
        Task<IEnumerable<Domain.News>> GetAll();
        Task<Domain.News> GetById(int id);
        Task<IEnumerable<Domain.News>> GetByNewsFeedIds(IEnumerable<int> feedIds);
    }
}
