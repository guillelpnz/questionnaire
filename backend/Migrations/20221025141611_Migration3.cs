using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionnaireId",
                table: "Questions",
                column: "QuestionnaireId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Questionnaire_QuestionnaireId",
                table: "Questions",
                column: "QuestionnaireId",
                principalTable: "Questionnaire",
                principalColumn: "QuestionnaireId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Questionnaire_QuestionnaireId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuestionnaireId",
                table: "Questions");
        }
    }
}
