using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hydro.DAL.Migrations
{
    public partial class addFreeClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DifferentReports",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Organization = table.Column<string>(nullable: false),
                    ReportType = table.Column<int>(nullable: false),
                    Position = table.Column<string>(nullable: false),
                    diffRepDate = table.Column<DateTime>(nullable: false),
                    Region = table.Column<string>(nullable: false),
                    Character = table.Column<string>(nullable: false),
                    Purpose = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DifferentReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NavigationWarnings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NavWarnDesc = table.Column<string>(nullable: false),
                    NavFileName = table.Column<string>(nullable: false),
                    WarnNumber = table.Column<string>(nullable: false),
                    WaringDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavigationWarnings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewFeatures",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Organization = table.Column<string>(nullable: false),
                    Position = table.Column<string>(nullable: false),
                    NewFeatureDate = table.Column<DateTime>(nullable: false),
                    Region = table.Column<string>(nullable: false),
                    Character = table.Column<string>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    Purpose = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NoticeToMariners",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoticeType = table.Column<int>(nullable: false),
                    NotiecDesc = table.Column<string>(nullable: false),
                    NoticeFileName = table.Column<string>(nullable: false),
                    NoticeDate = table.Column<DateTime>(nullable: false),
                    NoticeEdition = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticeToMariners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialTasks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Organization = table.Column<string>(nullable: false),
                    SpecialTaskType = table.Column<int>(nullable: false),
                    SpecialTaskDate = table.Column<DateTime>(nullable: false),
                    Purpose = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialTasks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DifferentReports");

            migrationBuilder.DropTable(
                name: "NavigationWarnings");

            migrationBuilder.DropTable(
                name: "NewFeatures");

            migrationBuilder.DropTable(
                name: "NoticeToMariners");

            migrationBuilder.DropTable(
                name: "SpecialTasks");
        }
    }
}
