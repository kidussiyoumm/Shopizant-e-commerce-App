using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopizant.CodeFirst.DAL.Migrations
{
    public partial class CartClassAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cart",
                columns: table => new
                {
                    ProductId = table.Column<string>(nullable: false),
                    ProductName = table.Column<string>(maxLength: 25, nullable: false),
                    EmailId = table.Column<string>( nullable: false),
                    Quantity = table.Column<byte>(maxLength: 25, nullable: false)
                    //ProductId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cart", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_cart_User_EmailId",
                        column: x => x.EmailId,
                        principalTable: "User",
                        principalColumn: "EmailId",
                        onDelete: ReferentialAction.Cascade);
                    //table.ForeignKey(
                    //    name: "FK_cart_Products_ProductId1",
                    //    //column: x => x.ProductId1,
                    //    principalTable: "Products",
                    //    principalColumn: "ProductId",
                    //    onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cart_EmailId",
                table: "cart",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_cart_ProductId1",
                table: "cart",
                column: "ProductId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cart");
        }
    }
}
