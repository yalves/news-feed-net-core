using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace news_feed.Data.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "NewsFeed",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Sports" });

            migrationBuilder.InsertData(
                table: "NewsFeed",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Politics" });

            migrationBuilder.InsertData(
                table: "NewsFeed",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "TV" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Content", "NewsFeedId", "Timestamp", "Title" },
                values: new object[] { 1, "Soccer is a pretty good game to play with your family", 1, new DateTime(2020, 9, 6, 21, 25, 5, 869, DateTimeKind.Local).AddTicks(2721), "Soccer" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Content", "NewsFeedId", "Timestamp", "Title" },
                values: new object[] { 2, "Will the coviid-19 pandemic be erased?", 2, new DateTime(2020, 9, 4, 21, 25, 5, 870, DateTimeKind.Local).AddTicks(683), "Brazilian politics" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Content", "NewsFeedId", "Timestamp", "Title" },
                values: new object[] { 3, "Once you get used to the cringe is a pretty good show", 3, new DateTime(2020, 9, 5, 21, 25, 5, 870, DateTimeKind.Local).AddTicks(738), "The Office" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "NewsFeed",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NewsFeed",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NewsFeed",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
