using Microsoft.EntityFrameworkCore.Migrations;

namespace Rental.Migrations
{
    public partial class AddedCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_CAR",
                columns: table => new
                {
                    A_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    A_COMPANY = table.Column<string>(nullable: true),
                    A_MODEL = table.Column<string>(nullable: true),
                    A_DISTANCE_DRIVEN = table.Column<int>(nullable: false),
                    A_NUMBER_OF_SEATS = table.Column<int>(nullable: false),
                    A_FUEL_TYPE = table.Column<string>(nullable: true),
                    A_TRANSMISSION = table.Column<string>(nullable: true),
                    A_IS_AVAILABLE = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_CAR", x => x.A_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_CAR");
        }
    }
}
