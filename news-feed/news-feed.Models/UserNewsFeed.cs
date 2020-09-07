using System;
using System.Collections.Generic;
using System.Text;

namespace news_feed.Models
{
    public class UserNewsFeed
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int NewsFeedId { get; set; }
        public NewsFeed NewsFeed { get; set; }
    }
}
