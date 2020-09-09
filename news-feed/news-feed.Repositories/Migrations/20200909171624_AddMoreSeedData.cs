using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace news_feed.Data.Migrations
{
    public partial class AddMoreSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Content", "Timestamp", "Title" },
                values: new object[] { "I bet your son will like to play with you", new DateTime(2020, 9, 8, 14, 16, 24, 585, DateTimeKind.Local).AddTicks(2179), "Soccer is a pretty good game to play with your family" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Content", "Timestamp", "Title" },
                values: new object[] { "Things are going crazy in brazilian politics", new DateTime(2020, 9, 6, 14, 16, 24, 586, DateTimeKind.Local).AddTicks(1775), "Will the covid-19 pandemic be erased?" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Content", "Timestamp", "Title" },
                values: new object[] { "Pam and Jim are the best couple ever", new DateTime(2020, 9, 7, 14, 16, 24, 586, DateTimeKind.Local).AddTicks(1828), "The Office: Once you get used to the cringe is a pretty good show" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Content", "NewsFeedId", "Timestamp", "Title" },
                values: new object[,]
                {
                    { 5, "I hope he's okay", 1, new DateTime(2020, 9, 8, 14, 16, 24, 586, DateTimeKind.Local).AddTicks(1529), "Neymar falls 126 times during match and breaks the world record" },
                    { 6, "Authorities are unreachable", 2, new DateTime(2020, 9, 6, 14, 16, 24, 586, DateTimeKind.Local).AddTicks(1794), "Water treatment in Brazil keeps compromised" },
                    { 4, "Will it be good this time?", 3, new DateTime(2020, 9, 7, 14, 16, 24, 586, DateTimeKind.Local).AddTicks(1852), "Game of thrones: A new ending is coming" }
                });

            migrationBuilder.InsertData(
                table: "NewsFeed",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Music" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Content", "NewsFeedId", "Timestamp", "Title" },
                values: new object[] { 7, "Some say people already ate the skirt", 4, new DateTime(2020, 9, 7, 14, 16, 24, 586, DateTimeKind.Local).AddTicks(1887), "Lady gaga's meat dress is found on a random butchery" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Content", "NewsFeedId", "Timestamp", "Title" },
                values: new object[] { 8, "Wow, nobody expected this", 4, new DateTime(2020, 9, 7, 14, 16, 24, 586, DateTimeKind.Local).AddTicks(1908), "Radiohead launches another slow and sad song" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "NewsFeed",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Content", "Timestamp", "Title" },
                values: new object[] { "Soccer is a pretty good game to play with your family", new DateTime(2020, 9, 6, 21, 25, 5, 869, DateTimeKind.Local).AddTicks(2721), "Soccer" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Content", "Timestamp", "Title" },
                values: new object[] { "Will the coviid-19 pandemic be erased?", new DateTime(2020, 9, 4, 21, 25, 5, 870, DateTimeKind.Local).AddTicks(683), "Brazilian politics" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Content", "Timestamp", "Title" },
                values: new object[] { "Once you get used to the cringe is a pretty good show", new DateTime(2020, 9, 5, 21, 25, 5, 870, DateTimeKind.Local).AddTicks(738), "The Office" });
        }
    }
}
