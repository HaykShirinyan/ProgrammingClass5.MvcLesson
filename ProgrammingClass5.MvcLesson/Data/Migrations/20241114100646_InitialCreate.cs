using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingClass5.MvcLesson.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstabLishedYear",
                table: "Manufacturers",
                newName: "EstablishedYear");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstablishedYear",
                table: "Manufacturers",
                newName: "EstabLishedYear");
        }
    }
}
