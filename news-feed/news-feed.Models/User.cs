using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace news_feed.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<UserNewsFeed> SubscribedFeeds { get; set; }
    }
}
