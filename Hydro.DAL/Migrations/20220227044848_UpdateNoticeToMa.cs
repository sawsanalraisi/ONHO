using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hydro.DAL.Migrations
{
    public partial class UpdateNoticeToMa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "NoticeToMariners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "NoticeToMariners",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "NoticeToMariners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "NoticeToMariners",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UploadeFile",
                table: "NoticeToMariners",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "DocumentFiles",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "NoticeToMariners");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "NoticeToMariners");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "NoticeToMariners");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "NoticeToMariners");

            migrationBuilder.DropColumn(
                name: "UploadeFile",
                table: "NoticeToMariners");

            migrationBuilder.AlterColumn<int>(
                name: "Path",
                table: "DocumentFiles",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
