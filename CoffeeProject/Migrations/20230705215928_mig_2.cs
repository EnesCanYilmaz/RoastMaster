using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeProject.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Customers",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Customers",
                newName: "FullName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Customers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Customers",
                newName: "FirstName");
        }
    }
}
