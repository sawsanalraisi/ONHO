using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hydro.DAL.Migrations
{
    public partial class RequestEntityUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Requests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Requests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "Requests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Requests");
        }
    }
}
