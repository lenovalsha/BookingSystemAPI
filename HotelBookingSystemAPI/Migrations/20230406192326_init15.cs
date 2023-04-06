using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBookingSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class init15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Positions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Positions_HotelId",
                table: "Positions",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Hotels_HotelId",
                table: "Positions",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Hotels_HotelId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Positions_HotelId",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Positions");
        }
    }
}
