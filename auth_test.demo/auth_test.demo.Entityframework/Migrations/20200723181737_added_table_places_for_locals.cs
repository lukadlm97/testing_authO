using Microsoft.EntityFrameworkCore.Migrations;

namespace auth_test.demo.Entityframework.Migrations
{
    public partial class added_table_places_for_locals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VenueType",
                table: "Venues",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TablePlaces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    UsualCapacity = table.Column<int>(nullable: false),
                    MinCapacity = table.Column<int>(nullable: false),
                    MaxCapacity = table.Column<int>(nullable: false),
                    IsSeparate = table.Column<bool>(nullable: false),
                    HaveMinimumSpend = table.Column<bool>(nullable: false),
                    MinimumSpend = table.Column<double>(nullable: false),
                    CostOfReservaton = table.Column<double>(nullable: false),
                    VenueId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablePlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TablePlaces_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TablePlaces_VenueId",
                table: "TablePlaces",
                column: "VenueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TablePlaces");

            migrationBuilder.DropColumn(
                name: "VenueType",
                table: "Venues");
        }
    }
}
