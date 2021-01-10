using Microsoft.EntityFrameworkCore.Migrations;

namespace CarInventory.Migrations
{
    public partial class Manufactureradd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Car");

            migrationBuilder.AddColumn<int>(
                name: "ManufacturerID",
                table: "Car",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_ManufacturerID",
                table: "Car",
                column: "ManufacturerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Manufacturer_ManufacturerID",
                table: "Car",
                column: "ManufacturerID",
                principalTable: "Manufacturer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Manufacturer_ManufacturerID",
                table: "Car");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropIndex(
                name: "IX_Car_ManufacturerID",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "ManufacturerID",
                table: "Car");

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Car",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
