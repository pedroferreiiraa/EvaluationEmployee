using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _5W2H.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class rename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_UserAvaliations_AvaliationId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_UserAvaliations_UserAvaliationId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answers",
                table: "Answers");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "UserQuestions");

            migrationBuilder.RenameTable(
                name: "Answers",
                newName: "UserAnswers");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_UserAvaliationId",
                table: "UserQuestions",
                newName: "IX_UserQuestions_UserAvaliationId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_QuestionId",
                table: "UserAnswers",
                newName: "IX_UserAnswers_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_AvaliationId_QuestionId",
                table: "UserAnswers",
                newName: "IX_UserAnswers_AvaliationId_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserQuestions",
                table: "UserQuestions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAnswers",
                table: "UserAnswers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_UserAvaliations_AvaliationId",
                table: "UserAnswers",
                column: "AvaliationId",
                principalTable: "UserAvaliations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_UserQuestions_QuestionId",
                table: "UserAnswers",
                column: "QuestionId",
                principalTable: "UserQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuestions_UserAvaliations_UserAvaliationId",
                table: "UserQuestions",
                column: "UserAvaliationId",
                principalTable: "UserAvaliations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_UserAvaliations_AvaliationId",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_UserQuestions_QuestionId",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserQuestions_UserAvaliations_UserAvaliationId",
                table: "UserQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserQuestions",
                table: "UserQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAnswers",
                table: "UserAnswers");

            migrationBuilder.RenameTable(
                name: "UserQuestions",
                newName: "Questions");

            migrationBuilder.RenameTable(
                name: "UserAnswers",
                newName: "Answers");

            migrationBuilder.RenameIndex(
                name: "IX_UserQuestions_UserAvaliationId",
                table: "Questions",
                newName: "IX_Questions_UserAvaliationId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnswers_QuestionId",
                table: "Answers",
                newName: "IX_Answers_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnswers_AvaliationId_QuestionId",
                table: "Answers",
                newName: "IX_Answers_AvaliationId_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answers",
                table: "Answers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_UserAvaliations_AvaliationId",
                table: "Answers",
                column: "AvaliationId",
                principalTable: "UserAvaliations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_UserAvaliations_UserAvaliationId",
                table: "Questions",
                column: "UserAvaliationId",
                principalTable: "UserAvaliations",
                principalColumn: "Id");
        }
    }
}
