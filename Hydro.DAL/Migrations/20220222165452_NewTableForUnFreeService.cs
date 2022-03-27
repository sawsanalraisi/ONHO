using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hydro.DAL.Migrations
{
    public partial class NewTableForUnFreeService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewSurveys",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Purpose = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<string>(nullable: true),
                    Isdelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewSurveys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    ld = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    States = table.Column<int>(nullable: false),
                    Isdelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.ld);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
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
                    Isdelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LegalDocuments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LegalDocuments = table.Column<string>(nullable: true),
                    Isdelete = table.Column<bool>(nullable: false),
                    NewSurveyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegalDocuments_NewSurveys_NewSurveyId",
                        column: x => x.NewSurveyId,
                        principalTable: "NewSurveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuveryFileFormats",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileType = table.Column<int>(nullable: false),
                    Isdelete = table.Column<bool>(nullable: false),
                    NewServeyId = table.Column<long>(nullable: false),
                    NewSurveyId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuveryFileFormats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuveryFileFormats_NewSurveys_NewSurveyId",
                        column: x => x.NewSurveyId,
                        principalTable: "NewSurveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FileFormats",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileType = table.Column<int>(nullable: false),
                    Isdelete = table.Column<bool>(nullable: false),
                    ServiceId = table.Column<long>(nullable: false),
                    ServiceRequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileFormats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileFormats_ServiceRequests_ServiceRequestId",
                        column: x => x.ServiceRequestId,
                        principalTable: "ServiceRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServcieTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceType = table.Column<int>(nullable: false),
                    Isdelete = table.Column<bool>(nullable: false),
                    ServiceId = table.Column<long>(nullable: false),
                    ServiceRequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServcieTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServcieTypes_ServiceRequests_ServiceRequestId",
                        column: x => x.ServiceRequestId,
                        principalTable: "ServiceRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileFormats_ServiceRequestId",
                table: "FileFormats",
                column: "ServiceRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalDocuments_NewSurveyId",
                table: "LegalDocuments",
                column: "NewSurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_ServcieTypes_ServiceRequestId",
                table: "ServcieTypes",
                column: "ServiceRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_SuveryFileFormats_NewSurveyId",
                table: "SuveryFileFormats",
                column: "NewSurveyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileFormats");

            migrationBuilder.DropTable(
                name: "LegalDocuments");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "ServcieTypes");

            migrationBuilder.DropTable(
                name: "SuveryFileFormats");

            migrationBuilder.DropTable(
                name: "ServiceRequests");

            migrationBuilder.DropTable(
                name: "NewSurveys");
        }
    }
}
