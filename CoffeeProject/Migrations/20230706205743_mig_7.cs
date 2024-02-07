using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeProject.Migrations
{
    /// <inheritdoc />
    public partial class mig_7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Coffee_CoffeeId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coffee",
                table: "Coffee");

            migrationBuilder.DropColumn(
                name: "CoffeeTypeID",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Coffee",
                newName: "Coffees");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Orders",
                newName: "TotalPrice");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coffees",
                table: "Coffees",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PaymentCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecurityCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentCards_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentCards_AppUserId",
                table: "PaymentCards",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Coffees_CoffeeId",
                table: "Orders",
                column: "CoffeeId",
                principalTable: "Coffees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Coffees_CoffeeId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "PaymentCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coffees",
                table: "Coffees");

            migrationBuilder.RenameTable(
                name: "Coffees",
                newName: "Coffee");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Orders",
                newName: "CustomerID");

            migrationBuilder.AddColumn<int>(
                name: "CoffeeTypeID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coffee",
                table: "Coffee",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Coffee_CoffeeId",
                table: "Orders",
                column: "CoffeeId",
                principalTable: "Coffee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
