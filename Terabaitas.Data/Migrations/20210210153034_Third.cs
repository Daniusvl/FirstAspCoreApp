using Microsoft.EntityFrameworkCore.Migrations;

namespace Terabaitas.Data.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderedProductAmounts",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderedProductIds",
                table: "Orders",
                newName: "OrderedProducts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderedProducts",
                table: "Orders",
                newName: "OrderedProductIds");

            migrationBuilder.AddColumn<string>(
                name: "OrderedProductAmounts",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
