using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Terabaitas.Data.Migrations
{
    public partial class fitht : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOrdered",
                table: "Orders");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ShopItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ShopItems");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "DateOrdered",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
