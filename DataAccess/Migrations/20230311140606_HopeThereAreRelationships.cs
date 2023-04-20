using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class HopeThereAreRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Vinyls_SongId",
                table: "Vinyls",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ShopId",
                table: "Stocks",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_VinylId",
                table: "Stocks",
                column: "VinylId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_ArtistId",
                table: "Songs",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_BandId",
                table: "Songs",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ArtistId",
                table: "Contracts",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_BandId",
                table: "Contracts",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_RecordLabelId",
                table: "Contracts",
                column: "RecordLabelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Artists_ArtistId",
                table: "Contracts",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Bands_BandId",
                table: "Contracts",
                column: "BandId",
                principalTable: "Bands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_RecordLabels_RecordLabelId",
                table: "Contracts",
                column: "RecordLabelId",
                principalTable: "RecordLabels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Artists_ArtistId",
                table: "Songs",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Bands_BandId",
                table: "Songs",
                column: "BandId",
                principalTable: "Bands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Shops_ShopId",
                table: "Stocks",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Vinyls_VinylId",
                table: "Stocks",
                column: "VinylId",
                principalTable: "Vinyls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vinyls_Songs_SongId",
                table: "Vinyls",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Artists_ArtistId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Bands_BandId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_RecordLabels_RecordLabelId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Artists_ArtistId",
                table: "Songs");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Bands_BandId",
                table: "Songs");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Shops_ShopId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Vinyls_VinylId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Vinyls_Songs_SongId",
                table: "Vinyls");

            migrationBuilder.DropIndex(
                name: "IX_Vinyls_SongId",
                table: "Vinyls");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_ShopId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_VinylId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Songs_ArtistId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_BandId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_ArtistId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_BandId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_RecordLabelId",
                table: "Contracts");
        }
    }
}
