using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class logMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserId",
                table: "UserProfiles",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "ActiveYears", "Age", "Description", "FirstName", "LastName", "Nationality" },
                values: new object[,]
                {
                    { 1, 1880, 37, "nothing to be known", "Vincent", "van Gogh", "Dutch" },
                    { 2, 1890, 91, "nothing to be known", "Pablo", "Picasso", "Spanish" },
                    { 3, 1858, 86, "nothing to be known", "Claude", "Monet", "French" },
                    { 4, 1472, 67, "nothing to be known", "Leonardo", "da Vinci", "Italian" },
                    { 5, 1494, 88, "nothing to be known", "Michelangelo", "Buonarroti", "Italian" },
                    { 6, 1919, 84, "nothing to be known", "Salvador", "Dali", "Spanish" },
                    { 7, 1625, 63, "nothing to be known", "Rembrandt", "van Rijn", "Dutch" },
                    { 8, 1880, 80, "nothing to be known", "Edvard", "Munch", "Norwegian" },
                    { 9, 1947, 44, "nothing to be known", "Jackson", "Pollock", "American" },
                    { 10, 1880, 55, "nothing to be known", "Gustav", "Klimt", "Austrian" }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Address", "Town" },
                values: new object[,]
                {
                    { 1, "123 Main St", "New York" },
                    { 2, "456 Elm St", "Los Angeles" },
                    { 3, "789 Oak St", "Chicago" },
                    { 4, "1011 Maple St", "Houston" },
                    { 5, "1213 Pine St", "Phoenix" },
                    { 6, "1415 Birch St", "Philadelphia" },
                    { 7, "1617 Cedar St", "San Antonio" },
                    { 8, "1819 Walnut St", "San Diego" },
                    { 9, "2021 Chestnut St", "Dallas" },
                    { 10, "2223 Maple St", "San Jose" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "ArtistId", "Lyrics", "Name", "RealiseDate" },
                values: new object[,]
                {
                    { 1, 2, "You Shook Me All Night Long", "Back in Black", null },
                    { 2, 3, "You Shook Me All Night Long", "Thriller", null },
                    { 3, 4, "You Shook Me All Night Long", "Rumours", null },
                    { 4, 2, "You Shook Me All Night Long", "The Joshua Tree", null },
                    { 5, 7, "You Shook Me All Night Long", "Nevermind", null },
                    { 6, 8, "You Shook Me All Night Long", "Abbey Road", null },
                    { 7, 9, "You Shook Me All Night Long", "Purple Rain", null },
                    { 8, 9, "You Shook Me All Night Long", "The Chronic", null },
                    { 12, 5, "You Shook Me All Night Long", "In Utero", null },
                    { 13, 1, "You Shook Me All Night Long", "Blonde on Blonde", null }
                });

            migrationBuilder.InsertData(
                table: "Vinyls",
                columns: new[] { "Id", "AlbumId", "Condition", "Durablility", "Edition", "Groove", "Material", "Size", "Speed" },
                values: new object[,]
                {
                    { 1, 1, "Mint", 8, "1", "", "Vinyl", 12L, "45 RPM" },
                    { 2, 2, "Very Good", 6, "2", "", "Vinyl", 12L, "45 RPM" },
                    { 3, 3, "Near Mint", 7, "3", "", "Vinyl", 10L, "45 RPM" },
                    { 4, 4, "Good", 5, "4", "", "Vinyl", 12L, "45 RPM" },
                    { 5, 5, "Very Good", 7, "5", "", "Vinyl", 12L, "45 RPM" },
                    { 6, 6, "Near Mint", 8, "7", "", "Vinyl", 12L, "45 RPM" },
                    { 7, 7, "Mint", 9, "8", "", "Vinyl", 7L, "45 RPM" },
                    { 8, 8, "Good", 6, "6", "", "Vinyl", 12L, "45 RPM" },
                    { 9, 12, "Very Good", 4, "9", "", "Vinyl", 12L, "45 RPM" },
                    { 10, 13, "Near Mint", 7, "10", "", "Vinyl", 10L, "45 RPM" },
                    { 11, 1, "Good", 3, "11", "", "Vinyl", 7L, "45 RPM" },
                    { 12, 1, "Not Good", 2, "12", "", "Vinyl", 7L, "45 RPM" }
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "AvailableVinyls", "Price", "ShopId", "VinylId" },
                values: new object[,]
                {
                    { 1, 10, 1299, 1, 1 },
                    { 2, 5, 899, 2, 3 },
                    { 3, 7, 1999, 3, 2 },
                    { 4, 20, 1499, 4, 4 },
                    { 5, 12, 499, 5, 5 },
                    { 6, 8, 799, 6, 6 },
                    { 7, 15, 1099, 7, 7 },
                    { 8, 3, 599, 8, 8 },
                    { 9, 18, 2499, 9, 9 },
                    { 10, 25, 1699, 10, 10 }
                });
        }
    }
}
