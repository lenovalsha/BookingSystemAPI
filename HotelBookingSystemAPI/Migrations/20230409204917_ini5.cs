using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBookingSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class ini5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Positions_PositionId",
                table: "Staffs");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_PositionId",
                table: "Staffs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_PositionId",
                table: "Staffs",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_HotelId",
                table: "Positions",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Positions_PositionId",
                table: "Staffs",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id");
        }
    }
}
