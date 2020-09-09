using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using news_feed.Domain;
using news_feed.Services;

namespace news_feed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        private readonly UserManager<ApplicationUser> _userManager;

        public SubscriptionController(ISubscriptionService subscriptionService, UserManager<ApplicationUser> userManager)
        {
            _subscriptionService = subscriptionService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe([FromBody] int newsFeedId)
        {
            var user = _userManager.Users.Include(x => x.SubscribedFeeds).FirstOrDefault(x => x.Id == _userManager.GetUserId(User));
            await _subscriptionService.Subscribe(user, newsFeedId).ConfigureAwait(false);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Unsubscribe([FromBody] int newsFeedId)
        {
            var user = _userManager.Users.Include(x => x.SubscribedFeeds).FirstOrDefault(x => x.Id == _userManager.GetUserId(User));
            await _subscriptionService.Unsubscribe(user, newsFeedId).ConfigureAwait(false);

            return Ok();
        }
    }
}
