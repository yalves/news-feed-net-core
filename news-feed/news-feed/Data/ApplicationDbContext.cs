using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using news_feed.Models;

namespace news_feed.Data
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
        }

        public DbSet<NewsFeed> NewsFeed { get; set; }
        public DbSet<News> News { get; set; }
        //public DbSet<UserNewsFeed> UserNewsFeed { get; set; }
    }
}
