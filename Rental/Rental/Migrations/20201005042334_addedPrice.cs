using Microsoft.EntityFrameworkCore.Migrations;

namespace Rental.Migrations
{
    public partial class addedPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "A_PRICE",
                table: "TBL_CAR",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "A_PRICE",
                table: "TBL_CAR");
        }
    }
}
