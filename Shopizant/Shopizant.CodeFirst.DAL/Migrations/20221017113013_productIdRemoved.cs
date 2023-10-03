using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopizant.CodeFirst.DAL.Migrations
{
    public partial class productIdRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cart_Products_ProductId1",
                table: "cart");

            migrationBuilder.DropIndex(
                name: "IX_cart_ProductId1",
                table: "cart");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "cart");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductId1",
                table: "cart",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_cart_ProductId1",
                table: "cart",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_cart_Products_ProductId1",
                table: "cart",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
