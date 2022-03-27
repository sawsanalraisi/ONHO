using Microsoft.EntityFrameworkCore.Migrations;

namespace Hydro.DAL.Migrations
{
    public partial class IsDeleteProberity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNo",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "Isdelete",
                table: "SpecialTasks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Isdelete",
                table: "NoticeToMariners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Isdelete",
                table: "NewFeatures",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Isdelete",
                table: "NavigationWarnings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Isdelete",
                table: "DifferentReports",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Isdelete",
                table: "SpecialTasks");

            migrationBuilder.DropColumn(
                name: "Isdelete",
                table: "NoticeToMariners");

            migrationBuilder.DropColumn(
                name: "Isdelete",
                table: "NewFeatures");

            migrationBuilder.DropColumn(
                name: "Isdelete",
                table: "NavigationWarnings");

            migrationBuilder.DropColumn(
                name: "Isdelete",
                table: "DifferentReports");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
