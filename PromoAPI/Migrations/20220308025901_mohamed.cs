using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromoAPI.Migrations
{
    public partial class mohamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "PromoParks");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "PromoParks",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PromoParks",
                newName: "Sorce");

            migrationBuilder.RenameColumn(
                name: "Established",
                table: "PromoParks",
                newName: "Date");

            migrationBuilder.AddColumn<string>(
                name: "Descbtion",
                table: "PromoParks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descbtion",
                table: "PromoParks");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "PromoParks",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "Sorce",
                table: "PromoParks",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "PromoParks",
                newName: "Established");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "PromoParks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
