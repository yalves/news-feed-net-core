using System;
using System.Collections.Generic;
using System.Text;

namespace news_feed.Domain
{
    public class UserNewsFeed
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int NewsFeedId { get; set; }
        public NewsFeed NewsFeed { get; set; }
    }
}
