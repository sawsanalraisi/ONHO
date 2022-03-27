using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hydro.DAL.Migrations
{
    public partial class NewTableForServiceRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceRequestTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductType = table.Column<int>(nullable: false),
                    CopyType = table.Column<int>(nullable: false),
                    Years = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Postion = table.Column<string>(nullable: true),
                    Purpose = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DataType = table.Column<int>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<string>(nullable: true),
                    Isdelete = table.Column<bool>(nullable: false),
                    ServiceTypeId = table.Column<long>(nullable: false),
                    ServcieTypeId = table.Column<long>(nullable: true),
                    FileFormatId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequestTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceRequestTypes_FileFormats_FileFormatId",
                        column: x => x.FileFormatId,
                        principalTable: "FileFormats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRequestTypes_ServcieTypes_ServcieTypeId",
                        column: x => x.ServcieTypeId,
                        principalTable: "ServcieTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequestTypes_FileFormatId",
                table: "ServiceRequestTypes",
                column: "FileFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequestTypes_ServcieTypeId",
                table: "ServiceRequestTypes",
                column: "ServcieTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceRequestTypes");
        }
    }
}
