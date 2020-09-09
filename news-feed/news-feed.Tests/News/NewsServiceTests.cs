using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using news_feed.Domain;
using news_feed.Repositories.News;
using news_feed.Repositories.NewsFeed;
using news_feed.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace news_feed.Tests
{
    public class NewsServiceTests
    {
        private INewsService _newsService;
        private Mock<INewsRepository> _newsRepositoryMock = new Mock<INewsRepository>();

        public NewsServiceTests()
        {
            _newsService = new NewsService(_newsRepositoryMock.Object);
        }

        [Fact]
        public async Task Given_a_valid_input_when_getting_by_id_should_get_from_the_repository()
        {
            // Arrange
            _newsRepositoryMock.Setup(x => x.GetById(2)).ReturnsAsync(new News
            {
                Id = 2,
                Title = "Dummy news title",
                Content = "Dummy news content",
                Timestamp = DateTime.Now
            });

            // Act
            var news = await _newsService.GetById(2).ConfigureAwait(false);

            // Assert
            news.Should().NotBeNull();
            news.Id.Should().Be(2);
            news.Title.Should().Be("Dummy news title");
            news.Content.Should().Be("Dummy news content");
            _newsRepositoryMock.Verify(x => x.GetById(2), Times.Once);
        }

        [Fact]
        public async Task Given_a_valid_input_when_getting_all_should_get_from_the_repository()
        {
            // Arrange
            _newsRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(new List<News>
            {
                new News
                {
                    Id = 1,
                    Title = "Dummy news title",
                    Content = "Dummy news content",
                    Timestamp = DateTime.Now
                },
                new News
                {
                    Id = 2,
                    Title = "Dummy news title",
                    Content = "Dummy news content",
                    Timestamp = DateTime.Now
                }
            });

            // Act
            var news = await _newsService.GetAll().ConfigureAwait(false);

            // Assert
            news.Should().NotBeNull();
            news.Should().HaveCount(2);
            _newsRepositoryMock.Verify(x => x.GetAll(), Times.Once);
        }

        [Fact]
        public async Task Given_a_valid_input_when_getting_by_news_feed_ids_should_get_from_the_repository()
        {
            // Arrange
            _newsRepositoryMock.Setup(x => x.GetByNewsFeedIds(It.IsAny<List<int>>())).ReturnsAsync(new List<News>
            {
                new News
                {
                    Id = 1,
                    Title = "Dummy news title",
                    Content = "Dummy news content",
                    Timestamp = DateTime.Now
                },
                new News
                {
                    Id = 2,
                    Title = "Dummy news title",
                    Content = "Dummy news content",
                    Timestamp = DateTime.Now
                }
            });

            // Act
            var ids = new List<int> { 1, 2, 3 };
            var news = await _newsService.GetByNewsFeedIds(ids).ConfigureAwait(false);

            // Assert
            news.Should().NotBeNull();
            news.Should().HaveCount(2);
            _newsRepositoryMock.Verify(x => x.GetByNewsFeedIds(ids), Times.Once);
        }
    }
}
