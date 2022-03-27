using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hydro.DAL.Migrations
{
    public partial class WNavigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "NavigationWarnings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "NavigationWarnings",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "NavigationWarnings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "NavigationWarnings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UploadeFile",
                table: "NavigationWarnings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "NavigationWarnings");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "NavigationWarnings");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "NavigationWarnings");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "NavigationWarnings");

            migrationBuilder.DropColumn(
                name: "UploadeFile",
                table: "NavigationWarnings");
        }
    }
}
