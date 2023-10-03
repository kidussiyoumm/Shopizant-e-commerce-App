using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopizant.CodeFirst.DAL.Migrations
{
    public partial class CreateShopizantDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardDetail",
                columns: table => new
                {
                    NameCard = table.Column<string>(nullable: false),
                    CardType = table.Column<string>(maxLength: 25, nullable: false),
                    CardNumber = table.Column<decimal>(maxLength: 25, nullable: false),
                    ExpDate = table.Column<DateTime>(nullable: false),
                    Cvv = table.Column<decimal>(nullable: false),
                    CardBalance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardDetail", x => x.NameCard);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<byte>(nullable: false),
                    RoleName = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<string>(nullable: false),
                    ProductName = table.Column<string>(maxLength: 25, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    QuantityAvailable = table.Column<int>(nullable: false),
                    CatrgoryId = table.Column<byte>(nullable: false),
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    EmailId = table.Column<string>(nullable: false),
                    Password = table.Column<string>(maxLength: 25, nullable: false),
                    Gender = table.Column<string>(maxLength: 10, nullable: false),
                    Address = table.Column<string>(maxLength: 30, nullable: false),
                    RoleId = table.Column<byte>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.EmailId);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseDetail",
                columns: table => new
                {
                    PurchaseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseName = table.Column<string>(maxLength: 25, nullable: false),
                    Email = table.Column<string>(maxLength: 25, nullable: false),
                    QuantityPurchased = table.Column<int>(nullable: false),
                    DayOfPurchase = table.Column<DateTime>(nullable: false),
                    UserEmailEmailId = table.Column<string>(nullable: true),
                    ProductNavProductId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetail", x => x.PurchaseID);
                    table.ForeignKey(
                        name: "FK_PurchaseDetail_Products_ProductNavProductId",
                        column: x => x.ProductNavProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseDetail_User_UserEmailEmailId",
                        column: x => x.UserEmailEmailId,
                        principalTable: "User",
                        principalColumn: "EmailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetail_ProductNavProductId",
                table: "PurchaseDetail",
                column: "ProductNavProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetail_UserEmailEmailId",
                table: "PurchaseDetail",
                column: "UserEmailEmailId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardDetail");

            migrationBuilder.DropTable(
                name: "PurchaseDetail");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
