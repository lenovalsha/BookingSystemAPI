using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBookingSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class init9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomsBooked_Bookings_BookingId",
                table: "RoomsBooked");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomsBooked_ReservationStatus_ReservationStatusId",
                table: "RoomsBooked");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomsBooked_Rooms_RoomId",
                table: "RoomsBooked");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomsBooked",
                table: "RoomsBooked");

            migrationBuilder.RenameTable(
                name: "RoomsBooked",
                newName: "Reservations");

            migrationBuilder.RenameIndex(
                name: "IX_RoomsBooked_RoomId",
                table: "Reservations",
                newName: "IX_Reservations_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomsBooked_ReservationStatusId",
                table: "Reservations",
                newName: "IX_Reservations_ReservationStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomsBooked_BookingId",
                table: "Reservations",
                newName: "IX_Reservations_BookingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Bookings_BookingId",
                table: "Reservations",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ReservationStatus_ReservationStatusId",
                table: "Reservations",
                column: "ReservationStatusId",
                principalTable: "ReservationStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Rooms_RoomId",
                table: "Reservations",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Bookings_BookingId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ReservationStatus_ReservationStatusId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Rooms_RoomId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "RoomsBooked");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_RoomId",
                table: "RoomsBooked",
                newName: "IX_RoomsBooked_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_ReservationStatusId",
                table: "RoomsBooked",
                newName: "IX_RoomsBooked_ReservationStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_BookingId",
                table: "RoomsBooked",
                newName: "IX_RoomsBooked_BookingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomsBooked",
                table: "RoomsBooked",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomsBooked_Bookings_BookingId",
                table: "RoomsBooked",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomsBooked_ReservationStatus_ReservationStatusId",
                table: "RoomsBooked",
                column: "ReservationStatusId",
                principalTable: "ReservationStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomsBooked_Rooms_RoomId",
                table: "RoomsBooked",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }
    }
}
