using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Checklist.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(nullable: false),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groceries",
                columns: table => new
                {
                    GroceryId = table.Column<Guid>(nullable: false),
                    GroceryName = table.Column<string>(nullable: true),
                    CategoryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groceries", x => x.GroceryId);
                    table.ForeignKey(
                        name: "FK_Groceries_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingList",
                columns: table => new
                {
                    ShoppingListId = table.Column<Guid>(nullable: false),
                    ShoppingListName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingList", x => x.ShoppingListId);
                    table.ForeignKey(
                        name: "FK_ShoppingList_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroceryShoppingList",
                columns: table => new
                {
                    GroceryId = table.Column<Guid>(nullable: false),
                    ShoppingListId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryShoppingList", x => new { x.GroceryId, x.ShoppingListId });
                    table.ForeignKey(
                        name: "FK_GroceryShoppingList_Groceries_GroceryId",
                        column: x => x.GroceryId,
                        principalTable: "Groceries",
                        principalColumn: "GroceryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroceryShoppingList_ShoppingList_ShoppingListId",
                        column: x => x.ShoppingListId,
                        principalTable: "ShoppingList",
                        principalColumn: "ShoppingListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groceries_CategoryId",
                table: "Groceries",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_GroceryShoppingList_ShoppingListId",
                table: "GroceryShoppingList",
                column: "ShoppingListId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingList_UserId",
                table: "ShoppingList",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroceryShoppingList");

            migrationBuilder.DropTable(
                name: "Groceries");

            migrationBuilder.DropTable(
                name: "ShoppingList");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
