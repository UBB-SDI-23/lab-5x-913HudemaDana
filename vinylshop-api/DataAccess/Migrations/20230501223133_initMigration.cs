using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveYears = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lyrics = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RealiseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArtistId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vinyls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Edition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Durablility = table.Column<int>(type: "int", nullable: true),
                    Size = table.Column<long>(type: "bigint", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Groove = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Speed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlbumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vinyls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vinyls_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvailableVinyls = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    VinylId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_Vinyls_VinylId",
                        column: x => x.VinylId,
                        principalTable: "Vinyls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "ActiveYears", "Age", "FirstName", "LastName", "Nationality" },
                values: new object[,]
                {
                    { 1, 1880, 37, "Vincent", "van Gogh", "Dutch" },
                    { 2, 1890, 91, "Pablo", "Picasso", "Spanish" },
                    { 3, 1858, 86, "Claude", "Monet", "French" },
                    { 4, 1472, 67, "Leonardo", "da Vinci", "Italian" },
                    { 5, 1494, 88, "Michelangelo", "Buonarroti", "Italian" },
                    { 6, 1919, 84, "Salvador", "Dali", "Spanish" },
                    { 7, 1625, 63, "Rembrandt", "van Rijn", "Dutch" },
                    { 8, 1880, 80, "Edvard", "Munch", "Norwegian" },
                    { 9, 1947, 44, "Jackson", "Pollock", "American" },
                    { 10, 1880, 55, "Gustav", "Klimt", "Austrian" }
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

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistId",
                table: "Albums",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ShopId",
                table: "Stocks",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_VinylId",
                table: "Stocks",
                column: "VinylId");

            migrationBuilder.CreateIndex(
                name: "IX_Vinyls_AlbumId",
                table: "Vinyls",
                column: "AlbumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "Vinyls");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}
