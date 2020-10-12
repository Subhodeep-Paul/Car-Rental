using Microsoft.EntityFrameworkCore.Migrations;

namespace Rental.Migrations
{
    public partial class addedadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "A_IS_ADMIN",
                table: "TBL_USER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "A_IS_ADMIN",
                table: "TBL_USER");
        }
    }
}
