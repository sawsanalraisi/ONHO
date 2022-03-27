using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hydro.DAL.Migrations
{
    public partial class CatRealationTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequestTypes_Categories_CategoriesId",
                table: "ServiceRequestTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequestTypes_FileFormats_FileFormatId",
                table: "ServiceRequestTypes");

            migrationBuilder.DropIndex(
                name: "IX_ServiceRequestTypes_CategoriesId",
                table: "ServiceRequestTypes");

            migrationBuilder.DropIndex(
                name: "IX_ServiceRequestTypes_FileFormatId",
                table: "ServiceRequestTypes");

            migrationBuilder.DropColumn(
                name: "CategorId",
                table: "ServiceRequestTypes");

            migrationBuilder.DropColumn(
                name: "CategoriesId",
                table: "ServiceRequestTypes");

            migrationBuilder.DropColumn(
                name: "CopyType",
                table: "ServiceRequestTypes");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "ServiceRequestTypes");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "ServiceRequestTypes");

            migrationBuilder.DropColumn(
                name: "DataType",
                table: "ServiceRequestTypes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ServiceRequestTypes");

            migrationBuilder.DropColumn(
                name: "FileFormatId",
                table: "ServiceRequestTypes");

            migrationBuilder.DropColumn(
                name: "Isdelete",
                table: "ServiceRequestTypes");

            migrationBuilder.DropColumn(
                name: "Postion",
                table: "ServiceRequestTypes");

            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "ServiceRequestTypes");

            migrationBuilder.DropColumn(
                name: "Purpose",
                table: "ServiceRequestTypes");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ServiceRequestTypes");

            migrationBuilder.DropColumn(
                name: "Years",
                table: "ServiceRequestTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CategorId",
                table: "ServiceRequestTypes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CategoriesId",
                table: "ServiceRequestTypes",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CopyType",
                table: "ServiceRequestTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "ServiceRequestTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "ServiceRequestTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DataType",
                table: "ServiceRequestTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ServiceRequestTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FileFormatId",
                table: "ServiceRequestTypes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "Isdelete",
                table: "ServiceRequestTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Postion",
                table: "ServiceRequestTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductType",
                table: "ServiceRequestTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Purpose",
                table: "ServiceRequestTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ServiceRequestTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Years",
                table: "ServiceRequestTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequestTypes_CategoriesId",
                table: "ServiceRequestTypes",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequestTypes_FileFormatId",
                table: "ServiceRequestTypes",
                column: "FileFormatId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequestTypes_Categories_CategoriesId",
                table: "ServiceRequestTypes",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequestTypes_FileFormats_FileFormatId",
                table: "ServiceRequestTypes",
                column: "FileFormatId",
                principalTable: "FileFormats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
