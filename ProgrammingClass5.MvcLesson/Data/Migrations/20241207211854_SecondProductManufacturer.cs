using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingClass5.MvcLesson.Data.Migrations
{
    /// <inheritdoc />
    public partial class SecondProductManufacturer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductManufacturerId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductManufacturerId",
                table: "Products",
                column: "ProductManufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductManufacturers_ProductManufacturerId",
                table: "Products",
                column: "ProductManufacturerId",
                principalTable: "ProductManufacturers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductManufacturers_ProductManufacturerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductManufacturerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductManufacturerId",
                table: "Products");
        }
    }
}
