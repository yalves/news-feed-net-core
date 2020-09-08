﻿using System;

namespace news_feed.Domain
{
    public class News
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime Timestamp { get; set; }

        public NewsFeed NewsFeed { get; set; }
    }
}
