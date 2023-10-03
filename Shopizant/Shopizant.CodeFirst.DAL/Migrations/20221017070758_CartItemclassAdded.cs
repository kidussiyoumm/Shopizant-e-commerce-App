using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopizant.CodeFirst.DAL.Migrations
{
    public partial class CartItemclassAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmailId",
                table: "cart",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.CreateTable(
                name: "cartItems",
                columns: table => new
                {
                    ProductId = table.Column<string>(nullable: false),
                    ProductName = table.Column<string>(maxLength: 25, nullable: false),
                    price = table.Column<decimal>(nullable: false),
                    QuantityAvailable = table.Column<int>(nullable: false),
                    Qunatity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartItems", x => x.ProductId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cartItems");

            migrationBuilder.AlterColumn<string>(
                name: "EmailId",
                table: "cart",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
