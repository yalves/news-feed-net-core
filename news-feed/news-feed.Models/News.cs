using System;

namespace news_feed.Models
{
    public class News
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
