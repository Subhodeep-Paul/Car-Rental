using Microsoft.EntityFrameworkCore.Migrations;

namespace Rental.Migrations
{
    public partial class addedFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "A_FK_CARID",
                table: "TBL_BOOKING",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "A_FK_USERID",
                table: "TBL_BOOKING",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TBL_BOOKING_A_FK_CARID",
                table: "TBL_BOOKING",
                column: "A_FK_CARID");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_BOOKING_A_FK_USERID",
                table: "TBL_BOOKING",
                column: "A_FK_USERID");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_BOOKING_TBL_CAR_A_FK_CARID",
                table: "TBL_BOOKING",
                column: "A_FK_CARID",
                principalTable: "TBL_CAR",
                principalColumn: "A_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_BOOKING_TBL_USER_A_FK_USERID",
                table: "TBL_BOOKING",
                column: "A_FK_USERID",
                principalTable: "TBL_USER",
                principalColumn: "A_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_BOOKING_TBL_CAR_A_FK_CARID",
                table: "TBL_BOOKING");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_BOOKING_TBL_USER_A_FK_USERID",
                table: "TBL_BOOKING");

            migrationBuilder.DropIndex(
                name: "IX_TBL_BOOKING_A_FK_CARID",
                table: "TBL_BOOKING");

            migrationBuilder.DropIndex(
                name: "IX_TBL_BOOKING_A_FK_USERID",
                table: "TBL_BOOKING");

            migrationBuilder.DropColumn(
                name: "A_FK_CARID",
                table: "TBL_BOOKING");

            migrationBuilder.DropColumn(
                name: "A_FK_USERID",
                table: "TBL_BOOKING");
        }
    }
}
