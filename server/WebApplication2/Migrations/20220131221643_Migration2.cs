using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_albumid",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_albumid",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "albumid",
                table: "Songs");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_album_id",
                table: "Songs",
                column: "album_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_album_id",
                table: "Songs",
                column: "album_id",
                principalTable: "Albums",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_album_id",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_album_id",
                table: "Songs");

            migrationBuilder.AddColumn<int>(
                name: "albumid",
                table: "Songs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_albumid",
                table: "Songs",
                column: "albumid");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_albumid",
                table: "Songs",
                column: "albumid",
                principalTable: "Albums",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
