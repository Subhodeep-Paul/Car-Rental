using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rental.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_USER",
                columns: table => new
                {
                    A_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    A_FIRST_NAME = table.Column<string>(nullable: true),
                    A_LAST_NAME = table.Column<string>(nullable: true),
                    A_EMAIL = table.Column<string>(nullable: true),
                    A_PASSWORD_HASH = table.Column<byte[]>(nullable: true),
                    A_PASSWORD_SALT = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_USER", x => x.A_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_USER");
        }
    }
}
