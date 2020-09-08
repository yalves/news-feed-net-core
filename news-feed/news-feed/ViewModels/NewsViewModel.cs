using news_feed.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace news_feed.ViewModels
{
    public class NewsViewModel
    {
        public IEnumerable<News> News { get; set; }
        public ApplicationUser User { get; set; }
    }
}
