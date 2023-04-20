using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class goodMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "RecordLabels");

            migrationBuilder.DropColumn(
                name: "BandId",
                table: "RecordLabels");

            migrationBuilder.DropColumn(
                name: "RecordLabelId",
                table: "Bands");

            migrationBuilder.DropColumn(
                name: "RecordLabelId",
                table: "Artists");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "RecordLabels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BandId",
                table: "RecordLabels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecordLabelId",
                table: "Bands",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecordLabelId",
                table: "Artists",
                type: "int",
                nullable: true);
        }
    }
}
