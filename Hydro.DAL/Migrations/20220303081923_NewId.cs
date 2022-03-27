using Microsoft.EntityFrameworkCore.Migrations;

namespace Hydro.DAL.Migrations
{
    public partial class NewId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "NewSurveyId",
                table: "LegalDocuments",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalDocuments_NewSurveys_NewSurveyId",
                table: "LegalDocuments");

            migrationBuilder.DropIndex(
                name: "IX_LegalDocuments_NewSurveyId",
                table: "LegalDocuments");

            migrationBuilder.DropColumn(
                name: "NewSurveyId",
                table: "LegalDocuments");
        }
    }
}
