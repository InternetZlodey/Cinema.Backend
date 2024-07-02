using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Persinstence.Migrations
{
    /// <inheritdoc />
    public partial class d1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Halls_HallId",
                table: "Seats");

            migrationBuilder.RenameColumn(
                name: "HallId",
                table: "Seats",
                newName: "HallID");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_HallId",
                table: "Seats",
                newName: "IX_Seats_HallID");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Halls_HallID",
                table: "Seats",
                column: "HallID",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Halls_HallID",
                table: "Seats");

            migrationBuilder.RenameColumn(
                name: "HallID",
                table: "Seats",
                newName: "HallId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_HallID",
                table: "Seats",
                newName: "IX_Seats_HallId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Halls_HallId",
                table: "Seats",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
