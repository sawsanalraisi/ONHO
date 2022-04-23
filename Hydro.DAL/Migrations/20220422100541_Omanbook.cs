using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hydro.DAL.Migrations
{
    public partial class Omanbook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImageNews",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    IdNews = table.Column<long>(nullable: false),
                    NewsId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageNews", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ImageNews_Newss_NewsId",
                        column: x => x.NewsId,
                        principalTable: "Newss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Omanbooks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(nullable: false),
                    UploadeFile = table.Column<string>(nullable: true),
                    Isdelete = table.Column<bool>(nullable: false),
                    CreateBy = table.Column<string>(nullable: true),
                    CreateAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Omanbooks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageNews_NewsId",
                table: "ImageNews",
                column: "NewsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageNews");

            migrationBuilder.DropTable(
                name: "Omanbooks");
        }
    }
}
