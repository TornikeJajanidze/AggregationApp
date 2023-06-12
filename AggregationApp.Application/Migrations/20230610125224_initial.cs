using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AggregationApp.Application.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aggregated_data",
                columns: table => new
                {
                    region = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    pplus = table.Column<decimal>(type: "numeric", nullable: false),
                    pminus = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aggregated_data", x => x.region);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aggregated_data");
        }
    }
}
