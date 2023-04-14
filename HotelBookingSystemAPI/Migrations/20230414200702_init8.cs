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
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Guests_GuestEmail",
                table: "Reservations");

            migrationBuilder.AlterColumn<string>(
                name: "GuestEmail",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Guests_GuestEmail",
                table: "Reservations",
                column: "GuestEmail",
                principalTable: "Guests",
                principalColumn: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Guests_GuestEmail",
                table: "Reservations");

            migrationBuilder.AlterColumn<string>(
                name: "GuestEmail",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Guests_GuestEmail",
                table: "Reservations",
                column: "GuestEmail",
                principalTable: "Guests",
                principalColumn: "Email",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
