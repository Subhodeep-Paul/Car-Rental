using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rental.Migrations
{
    public partial class addedbookingtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_BOOKING",
                columns: table => new
                {
                    A_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    A_LEASE_START_DATE = table.Column<DateTime>(nullable: false),
                    A_LEASE_END_DATE = table.Column<DateTime>(nullable: false),
                    A_TENURE = table.Column<int>(nullable: false),
                    A_PRICE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_BOOKING", x => x.A_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_BOOKING");
        }
    }
}
