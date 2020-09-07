using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace news_feed.Models
{
    public class User : IdentityUser
    {
        public ICollection<UserNewsFeed> SubscribedFeeds { get; set; }
    }
}
