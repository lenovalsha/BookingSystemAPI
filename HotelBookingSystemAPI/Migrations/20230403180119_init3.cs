using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBookingSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Hotels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_AdminId",
                table: "Hotels",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Admin_AdminId",
                table: "Hotels",
                column: "AdminId",
                principalTable: "Admin",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Admin_AdminId",
                table: "Hotels");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_AdminId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Hotels");
        }
    }
}
