using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addAttributesToEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Condition",
                table: "Vinyls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Durablility",
                table: "Vinyls",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Groove",
                table: "Vinyls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Material",
                table: "Vinyls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Size",
                table: "Vinyls",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Speed",
                table: "Vinyls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfAwards",
                table: "Bands",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfMembers",
                table: "Bands",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActiveYears",
                table: "Artists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Condition",
                table: "Vinyls");

            migrationBuilder.DropColumn(
                name: "Durablility",
                table: "Vinyls");

            migrationBuilder.DropColumn(
                name: "Groove",
                table: "Vinyls");

            migrationBuilder.DropColumn(
                name: "Material",
                table: "Vinyls");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Vinyls");

            migrationBuilder.DropColumn(
                name: "Speed",
                table: "Vinyls");

            migrationBuilder.DropColumn(
                name: "NumberOfAwards",
                table: "Bands");

            migrationBuilder.DropColumn(
                name: "NumberOfMembers",
                table: "Bands");

            migrationBuilder.DropColumn(
                name: "ActiveYears",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Artists");
        }
    }
}
