using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadingIsGood.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    ProductCode = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    LastName = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    UserName = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Role = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserInfo__1788CC4CF55D88A1", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Quantity = table.Column<int>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItem", x => x.Id);
                    table.ForeignKey(
                        name: "fk_pro_inv",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    UserInfoUserId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    OrderNumber = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrder", x => x.Id);
                    table.ForeignKey(
                        name: "fk_pro_sal",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_usr_sal",
                        column: x => x.UserInfoUserId,
                        principalTable: "UserInfo",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "IsActive", "Name", "ProductCode" },
                values: new object[,]
                {
                    { new Guid("2a2eb7b1-407c-44a2-9b6b-c7623f43f243"), true, "The Hitchhiker's Guide to the Galaxy", "Book1" },
                    { new Guid("4e297b40-7e29-45e6-bd0c-cad5884c3700"), true, "The Lord of the Rings Trilogy", "Book2" },
                    { new Guid("3435b3c4-45d2-4510-9f2d-748ff2a58fc3"), true, "The Pearl", "Book3" },
                    { new Guid("c6288e56-71a5-4f12-8f3c-addc55f5cf7a"), true, "The Hobbit", "Book4" }
                });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "UserId", "Address", "CreatedDate", "Email", "FirstName", "LastName", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { new Guid("61ca5534-af16-49d0-bd2d-9ea47557aecc"), "Ankara", new DateTime(2021, 1, 10, 14, 51, 26, 862, DateTimeKind.Local).AddTicks(8321), "mustsezgin@yahoo.com", "Mustafa", "Sezgin", "1", "Operator", "msezgin" },
                    { new Guid("b490fc38-c3af-440b-9a18-f29b54d7b5e9"), "California", new DateTime(2021, 1, 10, 14, 51, 26, 863, DateTimeKind.Local).AddTicks(8942), "hankmoody@moody.de", "Hank", "Moody", "1", "Customer", "hankmoody" }
                });

            migrationBuilder.InsertData(
                table: "InventoryItem",
                columns: new[] { "Id", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("4d5a57ce-fc83-4486-b6e3-1f52120505b6"), new Guid("2a2eb7b1-407c-44a2-9b6b-c7623f43f243"), 25 },
                    { new Guid("151a3d36-dfc0-46d6-96a8-d673745815c0"), new Guid("4e297b40-7e29-45e6-bd0c-cad5884c3700"), 45 },
                    { new Guid("26a0ed0d-32db-4e3f-912c-504802ea3a08"), new Guid("3435b3c4-45d2-4510-9f2d-748ff2a58fc3"), 15 },
                    { new Guid("626cb87f-e386-4865-a44e-2bd1d438d5db"), new Guid("c6288e56-71a5-4f12-8f3c-addc55f5cf7a"), 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItem_ProductId",
                table: "InventoryItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_ProductId",
                table: "SalesOrder",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_UserInfoUserId",
                table: "SalesOrder",
                column: "UserInfoUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryItem");

            migrationBuilder.DropTable(
                name: "SalesOrder");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
