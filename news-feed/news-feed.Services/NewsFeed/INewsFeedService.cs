using news_feed.Domain;
using System.Threading.Tasks;

namespace news_feed.Services
{
    public interface INewsFeedService
    {
        public Task<NewsFeed> GetById(int id);
    }
}
