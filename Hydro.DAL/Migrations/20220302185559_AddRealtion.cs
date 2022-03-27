using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hydro.DAL.Migrations
{
    public partial class AddRealtion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                table: "ServiceRequestTypes",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "CopyType",
                table: "ServiceRequestTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "ServiceRequestTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "ServiceRequestTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DataType",
                table: "ServiceRequestTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ServiceRequestTypes",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FileFormatId",
                table: "ServiceRequestTypes",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "Isdelete",
                table: "ServiceRequestTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Postion",
                table: "ServiceRequestTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductType",
                table: "ServiceRequestTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Purpose",
                table: "ServiceRequestTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ServiceRequestTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Years",
                table: "ServiceRequestTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequestTypes_CategoryId",
                table: "ServiceRequestTypes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequestTypes_FileFormatId",
                table: "ServiceRequestTypes",
                column: "FileFormatId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequestTypes_Categories_CategoryId",
                table: "ServiceRequestTypes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequestTypes_FileFormats_FileFormatId",
                table: "ServiceRequestTypes",
                column: "FileFormatId",
                principalTable: "FileFormats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequestTypes_Categories_CategoryId",
                table: "ServiceRequestTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequestTypes_FileFormats_FileFormatId",
                table: "ServiceRequestTypes");

            migrationBuilder.DropIndex(
                name: "IX_ServiceRequestTypes_CategoryId",
                table: "ServiceRequestTypes");

            migrationBuilder.DropIndex(
                name: "IX_ServiceRequestTypes_FileFormatId",
                table: "ServiceRequestTypes");

            migrationBuilder.DropColumn(
                name: "CategoryId",
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
    }
}
