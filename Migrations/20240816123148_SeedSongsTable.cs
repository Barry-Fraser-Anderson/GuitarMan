using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GuitarMan.Migrations
{
    /// <inheritdoc />
    public partial class SeedSongsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Artist", "Link", "Title" },
                values: new object[,]
                {
                    { 1, "4 Non Blondes", "https://www.youtube.com/watch?v=-7wsYYY1o98", "What's Up?" },
                    { 2, "Johnny Cash", "https://www.youtube.com/watch?v=CrQguKCnYTI", "Hurt" },
                    { 3, "Neil Young", "https://www.youtube.com/watch?v=U0MKyH48OhU", "Heart of Gold" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
