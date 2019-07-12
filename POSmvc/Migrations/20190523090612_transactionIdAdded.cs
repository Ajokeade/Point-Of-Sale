using Microsoft.EntityFrameworkCore.Migrations;

namespace POSmvc.Migrations
{
    public partial class transactionIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetail_Sales_SalesID",
                table: "SalesDetail");

            migrationBuilder.DropIndex(
                name: "IX_SalesDetail_SalesID",
                table: "SalesDetail");

            migrationBuilder.RenameColumn(
                name: "SalesID",
                table: "SalesDetail",
                newName: "TransctionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransctionID",
                table: "SalesDetail",
                newName: "SalesID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetail_SalesID",
                table: "SalesDetail",
                column: "SalesID");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDetail_Sales_SalesID",
                table: "SalesDetail",
                column: "SalesID",
                principalTable: "Sales",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
