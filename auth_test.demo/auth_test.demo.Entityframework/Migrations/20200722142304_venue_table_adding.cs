using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace auth_test.demo.Entityframework.Migrations
{
    public partial class venue_table_adding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VenueId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    OpenTime = table.Column<string>(nullable: true),
                    ClosedTime = table.Column<string>(nullable: true),
                    DateJoined = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Venues_VenueId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Venues");

            migrationBuilder.DropIndex(
                name: "IX_Users_VenueId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VenueId",
                table: "Users");
        }
    }
}
