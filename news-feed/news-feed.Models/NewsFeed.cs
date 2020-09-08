using System.Collections.Generic;

namespace news_feed.Domain
{
    public class NewsFeed
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<News> News { get; set; }
    }
}
