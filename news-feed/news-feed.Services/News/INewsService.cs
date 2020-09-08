using news_feed.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace news_feed.Services
{
    public interface INewsService
    {
        public Task<IEnumerable<News>> GetAll();
        public Task<News> GetById(int? id);
    }
}
