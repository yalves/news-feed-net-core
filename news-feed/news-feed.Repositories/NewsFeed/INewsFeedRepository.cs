using System.Threading.Tasks;

namespace news_feed.Repositories.NewsFeed
{
    public interface INewsFeedRepository
    {
        public Task<Domain.NewsFeed> GetById(int id);
    }
}
