using Microsoft.EntityFrameworkCore.Migrations;

namespace Rental.Migrations
{
    public partial class addedcity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "A_CITY",
                table: "TBL_USER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "A_CITY",
                table: "TBL_USER");
        }
    }
}
