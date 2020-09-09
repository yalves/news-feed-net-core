using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using news_feed.Domain;
using news_feed.Repositories.NewsFeed;
using news_feed.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace news_feed.Tests
{
    public class SubscriptionServiceTests
    {
        private ISubscriptionService _subscriptionService;
        private Mock<UserManager<ApplicationUser>> _userManagerMock;
        private Mock<INewsFeedRepository> _newsFeedRepositoryMock = new Mock<INewsFeedRepository>();

        public SubscriptionServiceTests()
        {
            _userManagerMock = MockUserManager<ApplicationUser>();
            _subscriptionService = new SubscriptionService(_newsFeedRepositoryMock.Object, _userManagerMock.Object);
        }

        [Fact]
        public async Task Given_a_valid_input_when_subscribing_should_update_the_user()
        {
            // Arrange
            _newsFeedRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(new NewsFeed
            {
                Id = 2,
                Name = "Sports"
            });

            var user = new ApplicationUser()
            {
                SubscribedFeeds = new List<UserNewsFeed>
                {
                    new UserNewsFeed
                    {
                        NewsFeedId = 1,
                        UserId = Guid.NewGuid().ToString()
                    }
                }
            };

            // Act
            await _subscriptionService.Subscribe(user, 2).ConfigureAwait(false);

            // Assert
            user.SubscribedFeeds.Should().HaveCount(2);
            _userManagerMock.Verify(x => x.UpdateAsync(user), Times.Once);
        }

        [Fact]
        public async Task Given_a_valid_input_when_unsubscribing_should_update_the_user()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser()
            {
                SubscribedFeeds = new List<UserNewsFeed>
                {
                    new UserNewsFeed
                    {
                        NewsFeedId = 1,
                        UserId = userId
                    },
                    new UserNewsFeed
                    {
                        NewsFeedId = 2,
                        UserId = userId
                    }
                }
            };

            // Act
            await _subscriptionService.Unsubscribe(user, 2).ConfigureAwait(false);

            // Assert
            user.SubscribedFeeds.Should().HaveCount(1);
            _userManagerMock.Verify(x => x.UpdateAsync(user), Times.Once);
        }


        private Mock<UserManager<TUser>> MockUserManager<TUser>() where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Object.UserValidators.Add(new UserValidator<TUser>());
            mgr.Object.PasswordValidators.Add(new PasswordValidator<TUser>());

            mgr.Setup(x => x.UpdateAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);

            return mgr;
        }
    }
}
