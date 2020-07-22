using Microsoft.EntityFrameworkCore.Migrations;

namespace auth_test.demo.Entityframework.Migrations
{
    public partial class manage_venue_demonstrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Venues_VenueId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_VenueId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VenueId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "ManageVenueId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Manages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VenueId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manages_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ManageVenueId",
                table: "Users",
                column: "ManageVenueId");

            migrationBuilder.CreateIndex(
                name: "IX_Manages_VenueId",
                table: "Manages",
                column: "VenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Manages_ManageVenueId",
                table: "Users",
                column: "ManageVenueId",
                principalTable: "Manages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Manages_ManageVenueId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Manages");

            migrationBuilder.DropIndex(
                name: "IX_Users_ManageVenueId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ManageVenueId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "VenueId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_VenueId",
                table: "Users",
                column: "VenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Venues_VenueId",
                table: "Users",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
