using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hydro.DAL.Migrations
{
    public partial class NewSTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BeforProcess",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackId = table.Column<string>(nullable: true),
                    OperationId = table.Column<long>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    OrderId = table.Column<long>(nullable: false),
                    CreateBy = table.Column<string>(nullable: true),
                    CreateAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeforProcess", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Newss",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleArbic = table.Column<string>(nullable: true),
                    TitleEnglish = table.Column<string>(nullable: true),
                    DescArbic = table.Column<string>(nullable: true),
                    DescEnglish = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<string>(nullable: true),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    CoverImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newss", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeforProcess");

            migrationBuilder.DropTable(
                name: "Newss");
        }
    }
}
