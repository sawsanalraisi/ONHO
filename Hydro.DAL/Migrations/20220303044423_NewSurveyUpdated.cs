using Microsoft.EntityFrameworkCore.Migrations;

namespace Hydro.DAL.Migrations
{
    public partial class NewSurveyUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalDocuments_NewSurveys_NewSurveyId",
                table: "LegalDocuments");

            migrationBuilder.DropIndex(
                name: "IX_LegalDocuments_NewSurveyId",
                table: "LegalDocuments");

            migrationBuilder.DropColumn(
                name: "LegalDocuments",
                table: "LegalDocuments");

            migrationBuilder.DropColumn(
                name: "NewSurveyId",
                table: "LegalDocuments");

            migrationBuilder.AddColumn<long>(
                name: "FileFormatId",
                table: "NewSurveys",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "LegalDocumentsType",
                table: "LegalDocuments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "LegalDocuments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NewSurveys_FileFormatId",
                table: "NewSurveys",
                column: "FileFormatId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewSurveys_FileFormats_FileFormatId",
                table: "NewSurveys",
                column: "FileFormatId",
                principalTable: "FileFormats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewSurveys_FileFormats_FileFormatId",
                table: "NewSurveys");

            migrationBuilder.DropIndex(
                name: "IX_NewSurveys_FileFormatId",
                table: "NewSurveys");

            migrationBuilder.DropColumn(
                name: "FileFormatId",
                table: "NewSurveys");

            migrationBuilder.DropColumn(
                name: "LegalDocumentsType",
                table: "LegalDocuments");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "LegalDocuments");

            migrationBuilder.AddColumn<string>(
                name: "LegalDocuments",
                table: "LegalDocuments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "NewSurveyId",
                table: "LegalDocuments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_LegalDocuments_NewSurveyId",
                table: "LegalDocuments",
                column: "NewSurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalDocuments_NewSurveys_NewSurveyId",
                table: "LegalDocuments",
                column: "NewSurveyId",
                principalTable: "NewSurveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
