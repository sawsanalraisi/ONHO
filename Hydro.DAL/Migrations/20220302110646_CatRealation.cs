using Microsoft.EntityFrameworkCore.Migrations;

namespace Hydro.DAL.Migrations
{
    public partial class CatRealation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CategorId",
                table: "ServiceRequestTypes",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CategoriesId",
                table: "ServiceRequestTypes",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FileFormatId",
                table: "ServiceRequestTypes",
                nullable: false,
                defaultValue: 0L);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FileFormatId",
                table: "ServiceRequestTypes");
        }
    }
}
