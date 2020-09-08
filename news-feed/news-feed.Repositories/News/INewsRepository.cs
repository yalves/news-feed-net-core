using System.Collections.Generic;
using System.Threading.Tasks;
using news_feed.Domain;

namespace news_feed.Repositories.News
{
    public interface INewsRepository
    {
        public Task<IEnumerable<Domain.News>> GetAll();

        public Task<Domain.News> GetById(int id);
    }
}
