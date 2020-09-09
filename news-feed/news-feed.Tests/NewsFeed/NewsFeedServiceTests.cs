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
    public class NewsFeedServiceTests
    {
        private INewsFeedService _newsFeedService;
        private Mock<INewsFeedRepository> _newsFeedRepositoryMock = new Mock<INewsFeedRepository>();

        public NewsFeedServiceTests()
        {
            _newsFeedService = new NewsFeedService(_newsFeedRepositoryMock.Object);
        }

        [Fact]
        public async Task Given_a_valid_input_when_getting_by_id_should_get_from_the_repository()
        {
            // Arrange
            _newsFeedRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(new NewsFeed
            {
                Id = 2,
                Name = "Sports"
            });

            // Act
            var newsFeed = await _newsFeedService.GetById(2).ConfigureAwait(false);

            // Assert
            newsFeed.Should().NotBeNull();
            newsFeed.Id.Should().Be(2);
            newsFeed.Name.Should().Be("Sports");
            _newsFeedRepositoryMock.Verify(x => x.GetById(2), Times.Once);
        }
    }
}
