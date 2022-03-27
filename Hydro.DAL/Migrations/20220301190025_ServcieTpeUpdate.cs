using Microsoft.EntityFrameworkCore.Migrations;

namespace Hydro.DAL.Migrations
{
    public partial class ServcieTpeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "ServcieTypes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "ServcieTypes");
        }
    }
}
