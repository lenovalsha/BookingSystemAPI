using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBookingSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class init8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservationStatusId",
                table: "RoomsBooked",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReservationStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomsBooked_ReservationStatusId",
                table: "RoomsBooked",
                column: "ReservationStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomsBooked_ReservationStatus_ReservationStatusId",
                table: "RoomsBooked",
                column: "ReservationStatusId",
                principalTable: "ReservationStatus",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomsBooked_ReservationStatus_ReservationStatusId",
                table: "RoomsBooked");

            migrationBuilder.DropTable(
                name: "ReservationStatus");

            migrationBuilder.DropIndex(
                name: "IX_RoomsBooked_ReservationStatusId",
                table: "RoomsBooked");

            migrationBuilder.DropColumn(
                name: "ReservationStatusId",
                table: "RoomsBooked");
        }
    }
}
