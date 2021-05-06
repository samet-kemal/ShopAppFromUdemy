using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopApp.DataAccess.Migrations
{
    public partial class CartEntitiesEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItemss_Carts_CartId",
                table: "CartItemss");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItemss_Products_ProductId",
                table: "CartItemss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItemss",
                table: "CartItemss");

            migrationBuilder.RenameTable(
                name: "CartItemss",
                newName: "CartItem");

            migrationBuilder.RenameIndex(
                name: "IX_CartItemss_ProductId",
                table: "CartItem",
                newName: "IX_CartItem_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItemss_CartId",
                table: "CartItem",
                newName: "IX_CartItem_CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItem",
                table: "CartItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Carts_CartId",
                table: "CartItem",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Products_ProductId",
                table: "CartItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Carts_CartId",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Products_ProductId",
                table: "CartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItem",
                table: "CartItem");

            migrationBuilder.RenameTable(
                name: "CartItem",
                newName: "CartItemss");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_ProductId",
                table: "CartItemss",
                newName: "IX_CartItemss_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_CartId",
                table: "CartItemss",
                newName: "IX_CartItemss_CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItemss",
                table: "CartItemss",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItemss_Carts_CartId",
                table: "CartItemss",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItemss_Products_ProductId",
                table: "CartItemss",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
