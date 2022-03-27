using Microsoft.EntityFrameworkCore.Migrations;

namespace Hydro.DAL.Migrations
{
    public partial class UpdateServiceRequestRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileFormats_ServiceRequests_ServiceRequestId",
                table: "FileFormats");

            migrationBuilder.DropForeignKey(
                name: "FK_ServcieTypes_ServiceRequests_ServiceRequestId",
                table: "ServcieTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_SuveryFileFormats_NewSurveys_NewSurveyId",
                table: "SuveryFileFormats");

            migrationBuilder.DropIndex(
                name: "IX_SuveryFileFormats_NewSurveyId",
                table: "SuveryFileFormats");

            migrationBuilder.DropIndex(
                name: "IX_ServcieTypes_ServiceRequestId",
                table: "ServcieTypes");

            migrationBuilder.DropIndex(
                name: "IX_FileFormats_ServiceRequestId",
                table: "FileFormats");

            migrationBuilder.DropColumn(
                name: "NewServeyId",
                table: "SuveryFileFormats");

            migrationBuilder.DropColumn(
                name: "NewSurveyId",
                table: "SuveryFileFormats");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "ServcieTypes");

            migrationBuilder.DropColumn(
                name: "ServiceRequestId",
                table: "ServcieTypes");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "FileFormats");

            migrationBuilder.DropColumn(
                name: "ServiceRequestId",
                table: "FileFormats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "NewServeyId",
                table: "SuveryFileFormats",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "NewSurveyId",
                table: "SuveryFileFormats",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ServiceId",
                table: "ServcieTypes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "ServiceRequestId",
                table: "ServcieTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ServiceId",
                table: "FileFormats",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "ServiceRequestId",
                table: "FileFormats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SuveryFileFormats_NewSurveyId",
                table: "SuveryFileFormats",
                column: "NewSurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_ServcieTypes_ServiceRequestId",
                table: "ServcieTypes",
                column: "ServiceRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_FileFormats_ServiceRequestId",
                table: "FileFormats",
                column: "ServiceRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileFormats_ServiceRequests_ServiceRequestId",
                table: "FileFormats",
                column: "ServiceRequestId",
                principalTable: "ServiceRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServcieTypes_ServiceRequests_ServiceRequestId",
                table: "ServcieTypes",
                column: "ServiceRequestId",
                principalTable: "ServiceRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SuveryFileFormats_NewSurveys_NewSurveyId",
                table: "SuveryFileFormats",
                column: "NewSurveyId",
                principalTable: "NewSurveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
