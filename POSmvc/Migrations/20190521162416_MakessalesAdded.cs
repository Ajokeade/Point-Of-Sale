using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POSmvc.Migrations
{
    public partial class MakessalesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_SalesDetail_SalesDetailID",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_SalesDetailID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SalesDetailID",
                table: "Product");

            migrationBuilder.CreateTable(
                name: "MakeSales",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    QuanitityPurchased = table.Column<int>(nullable: false),
                    SubTotal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MakeSales", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetail_ProductID",
                table: "SalesDetail",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDetail_Product_ProductID",
                table: "SalesDetail",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetail_Product_ProductID",
                table: "SalesDetail");

            migrationBuilder.DropTable(
                name: "MakeSales");

            migrationBuilder.DropIndex(
                name: "IX_SalesDetail_ProductID",
                table: "SalesDetail");

            migrationBuilder.AddColumn<int>(
                name: "SalesDetailID",
                table: "Product",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_SalesDetailID",
                table: "Product",
                column: "SalesDetailID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_SalesDetail_SalesDetailID",
                table: "Product",
                column: "SalesDetailID",
                principalTable: "SalesDetail",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
