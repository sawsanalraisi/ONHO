using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hydro.DAL.Migrations
{
    public partial class AddServiceReguestPro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CopyType",
                table: "ServiceRequestTypes");

            migrationBuilder.DropColumn(
                name: "DataType",
                table: "ServiceRequestTypes");

            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "ServiceRequestTypes");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "ServiceRequestTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateAt",
                table: "ServiceRequestTypes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateBy",
                table: "ServiceRequestTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Region",
                table: "ServiceRequestTypes");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "ServiceRequestTypes");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "ServiceRequestTypes");

            migrationBuilder.AddColumn<int>(
                name: "CopyType",
                table: "ServiceRequestTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DataType",
                table: "ServiceRequestTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductType",
                table: "ServiceRequestTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
