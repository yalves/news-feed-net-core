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

            modelBuilder.Entity<NewsFeed>()
                .HasMany(x => x.News)
                .WithOne(x => x.NewsFeed);

            AddSeedData(modelBuilder);
        }

        private void AddSeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewsFeed>().HasData(new NewsFeed { Id = 1, Name = "Sports" });
            modelBuilder.Entity<Domain.News>().HasData(new 
            { 
                Id = 1, 
                Title = "Soccer", 
                Content = "Soccer is a pretty good game to play with your family",
                Timestamp = DateTime.Now.AddDays(-1),
                NewsFeedId = 1,
            });


            modelBuilder.Entity<NewsFeed>().HasData(new NewsFeed { Id = 2, Name = "Politics" });
            modelBuilder.Entity<Domain.News>().HasData(new
            {
                Id = 2,
                Title = "Brazilian politics",
                Content = "Will the covid-19 pandemic be erased?",
                Timestamp = DateTime.Now.AddDays(-3),
                NewsFeedId = 2
            });

            modelBuilder.Entity<NewsFeed>().HasData(new NewsFeed { Id = 3, Name = "TV" });
            modelBuilder.Entity<Domain.News>().HasData(new
            {
                Id = 3,
                Title = "The Office",
                Content = "Once you get used to the cringe is a pretty good show",
                Timestamp = DateTime.Now.AddDays(-2),
                NewsFeedId = 3
            });
        }

        public DbSet<NewsFeed> NewsFeed { get; set; }
        public DbSet<Domain.News> News { get; set; }
        public DbSet<UserNewsFeed> UserNewsFeed { get; set; }
    }
}
