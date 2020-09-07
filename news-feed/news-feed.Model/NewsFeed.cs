using System.Collections.Generic;

namespace news_feed.Model
{
    public class NewsFeed
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<News> News { get; set; }
    }
}
