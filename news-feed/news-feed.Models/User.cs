using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace news_feed.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<UserNewsFeed> SubscribedFeeds { get; set; }
    }
}
