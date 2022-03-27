using Microsoft.EntityFrameworkCore.Migrations;

namespace Hydro.DAL.Migrations
{
    public partial class removeAddServiceId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequestTypes_FileFormats_FileFormatId",
                table: "ServiceRequestTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequestTypes_ServcieTypes_ServcieTypeId",
                table: "ServiceRequestTypes");

            migrationBuilder.DropIndex(
                name: "IX_ServiceRequestTypes_FileFormatId",
                table: "ServiceRequestTypes");

            migrationBuilder.DropIndex(
                name: "IX_ServiceRequestTypes_ServcieTypeId",
                table: "ServiceRequestTypes");

            migrationBuilder.DropColumn(
                name: "FileFormatId",
                table: "ServiceRequestTypes");

            migrationBuilder.DropColumn(
                name: "ServcieTypeId",
                table: "ServiceRequestTypes");

            migrationBuilder.DropColumn(
                name: "ServiceTypeId",
                table: "ServiceRequestTypes");

            migrationBuilder.DropColumn(
                name: "ServiceType",
                table: "ServcieTypes");

            migrationBuilder.AddColumn<int>(
                name: "EnumServiceType",
                table: "ServcieTypes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnumServiceType",
                table: "ServcieTypes");

            migrationBuilder.AddColumn<long>(
                name: "FileFormatId",
                table: "ServiceRequestTypes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ServcieTypeId",
                table: "ServiceRequestTypes",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ServiceTypeId",
                table: "ServiceRequestTypes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "ServiceType",
                table: "ServcieTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequestTypes_FileFormatId",
                table: "ServiceRequestTypes",
                column: "FileFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequestTypes_ServcieTypeId",
                table: "ServiceRequestTypes",
                column: "ServcieTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequestTypes_FileFormats_FileFormatId",
                table: "ServiceRequestTypes",
                column: "FileFormatId",
                principalTable: "FileFormats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequestTypes_ServcieTypes_ServcieTypeId",
                table: "ServiceRequestTypes",
                column: "ServcieTypeId",
                principalTable: "ServcieTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
