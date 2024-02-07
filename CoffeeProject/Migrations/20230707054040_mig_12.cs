using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeProject.Migrations
{
    /// <inheritdoc />
    public partial class mig_12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentCards_AspNetUsers_AppUserId",
                table: "PaymentCards");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PaymentCards");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "PaymentCards",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentCards_AspNetUsers_AppUserId",
                table: "PaymentCards",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentCards_AspNetUsers_AppUserId",
                table: "PaymentCards");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "PaymentCards",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "PaymentCards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentCards_AspNetUsers_AppUserId",
                table: "PaymentCards",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
