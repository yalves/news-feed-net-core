using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using news_feed.Domain;

namespace news_feed.Repositories.EntityFramework
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserNewsFeed>()
                .HasKey(x => new { x.UserId, x.NewsFeedId });

            modelBuilder.Entity<UserNewsFeed>()
                .HasOne(x => x.User)
                .WithMany(x => x.SubscribedFeeds)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<UserNewsFeed>()
                .HasOne(x => x.NewsFeed)
                .WithMany()
                .HasForeignKey(x => x.NewsFeedId);

            modelBuilder.Entity<Domain.NewsFeed>()
                .HasMany(x => x.News)
                .WithOne(x => x.NewsFeed);

            AddSeedData(modelBuilder);
        }

        private void AddSeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.NewsFeed>().HasData(new Domain.NewsFeed { Id = 1, Name = "Sports" });
            modelBuilder.Entity<Domain.News>().HasData(new 
            { 
                Id = 1, 
                Title = "Soccer is a pretty good game to play with your family", 
                Content = "I bet your son will like to play with you",
                Timestamp = DateTime.Now.AddDays(-1),
                NewsFeedId = 1,
            });
            modelBuilder.Entity<Domain.News>().HasData(new
            {
                Id = 5,
                Title = "Neymar falls 126 times during match and breaks the world record",
                Content = "I hope he's okay",
                Timestamp = DateTime.Now.AddDays(-1),
                NewsFeedId = 1,
            });

            modelBuilder.Entity<Domain.NewsFeed>().HasData(new Domain.NewsFeed { Id = 2, Name = "Politics" });
            modelBuilder.Entity<Domain.News>().HasData(new
            {
                Id = 2,
                Title = "Will the covid-19 pandemic be erased?",
                Content = "Things are going crazy in brazilian politics",
                Timestamp = DateTime.Now.AddDays(-3),
                NewsFeedId = 2
            });
            modelBuilder.Entity<Domain.News>().HasData(new
            {
                Id = 6,
                Title = "Water treatment in Brazil keeps compromised",
                Content = "Authorities are unreachable",
                Timestamp = DateTime.Now.AddDays(-3),
                NewsFeedId = 2
            });

            modelBuilder.Entity<Domain.NewsFeed>().HasData(new Domain.NewsFeed { Id = 3, Name = "TV" });
            modelBuilder.Entity<Domain.News>().HasData(new
            {
                Id = 3,
                Title = "The Office: Once you get used to the cringe is a pretty good show",
                Content = "Pam and Jim are the best couple ever",
                Timestamp = DateTime.Now.AddDays(-2),
                NewsFeedId = 3
            });
            modelBuilder.Entity<Domain.News>().HasData(new
            {
                Id = 4,
                Title = "Game of thrones: A new ending is coming",
                Content = "Will it be good this time?",
                Timestamp = DateTime.Now.AddDays(-2),
                NewsFeedId = 3
            });

            modelBuilder.Entity<Domain.NewsFeed>().HasData(new Domain.NewsFeed { Id = 4, Name = "Music" });
            modelBuilder.Entity<Domain.News>().HasData(new
            {
                Id = 7,
                Title = "Lady gaga's meat dress is found on a random butchery",
                Content = "Some say people already ate the skirt",
                Timestamp = DateTime.Now.AddDays(-2),
                NewsFeedId = 4
            });
            modelBuilder.Entity<Domain.News>().HasData(new
            {
                Id = 8,
                Title = "Radiohead launches another slow and sad song",
                Content = "Wow, nobody expected this",
                Timestamp = DateTime.Now.AddDays(-2),
                NewsFeedId = 4
            });
        }

        public DbSet<Domain.NewsFeed> NewsFeed { get; set; }
        public DbSet<Domain.News> News { get; set; }
        public DbSet<UserNewsFeed> UserNewsFeed { get; set; }
    }
}
