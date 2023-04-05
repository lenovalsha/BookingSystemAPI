using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBookingSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Admins_AdminId",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_AdminId",
                table: "Hotels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admins",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Admins");

            migrationBuilder.AddColumn<string>(
                name: "AdminUsername",
                table: "Hotels",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Admins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admins",
                table: "Admins",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_AdminUsername",
                table: "Hotels",
                column: "AdminUsername");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Admins_AdminUsername",
                table: "Hotels",
                column: "AdminUsername",
                principalTable: "Admins",
                principalColumn: "Username");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Admins_AdminUsername",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_AdminUsername",
                table: "Hotels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admins",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "AdminUsername",
                table: "Hotels");

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Hotels",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Admins",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admins",
                table: "Admins",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_AdminId",
                table: "Hotels",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Admins_AdminId",
                table: "Hotels",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id");
        }
    }
}
