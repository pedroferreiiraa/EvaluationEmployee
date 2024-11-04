using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _5W2H.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class completedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaderQuestions_LeaderAvaliations_LeaderAvaliationId",
                table: "LeaderQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserQuestions_UserAvaliations_UserAvaliationId",
                table: "UserQuestions");

            migrationBuilder.DropColumn(
                name: "StartedAt",
                table: "UserAvaliations");

            migrationBuilder.DropColumn(
                name: "StartedAt",
                table: "LeaderAvaliations");

            migrationBuilder.RenameColumn(
                name: "UserAvaliationId",
                table: "UserQuestions",
                newName: "UserEvaluationId");

            migrationBuilder.RenameIndex(
                name: "IX_UserQuestions_UserAvaliationId",
                table: "UserQuestions",
                newName: "IX_UserQuestions_UserEvaluationId");

            migrationBuilder.RenameColumn(
                name: "LeaderAvaliationId",
                table: "LeaderQuestions",
                newName: "LeaderEvaluationId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaderQuestions_LeaderAvaliationId",
                table: "LeaderQuestions",
                newName: "IX_LeaderQuestions_LeaderEvaluationId");

            migrationBuilder.AddColumn<string>(
                name: "DateReference",
                table: "UserAvaliations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "UserAvaliations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DateReference",
                table: "LeaderAvaliations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "LeaderAvaliations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaderQuestions_LeaderAvaliations_LeaderEvaluationId",
                table: "LeaderQuestions",
                column: "LeaderEvaluationId",
                principalTable: "LeaderAvaliations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuestions_UserAvaliations_UserEvaluationId",
                table: "UserQuestions",
                column: "UserEvaluationId",
                principalTable: "UserAvaliations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaderQuestions_LeaderAvaliations_LeaderEvaluationId",
                table: "LeaderQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserQuestions_UserAvaliations_UserEvaluationId",
                table: "UserQuestions");

            migrationBuilder.DropColumn(
                name: "DateReference",
                table: "UserAvaliations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "UserAvaliations");

            migrationBuilder.DropColumn(
                name: "DateReference",
                table: "LeaderAvaliations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "LeaderAvaliations");

            migrationBuilder.RenameColumn(
                name: "UserEvaluationId",
                table: "UserQuestions",
                newName: "UserAvaliationId");

            migrationBuilder.RenameIndex(
                name: "IX_UserQuestions_UserEvaluationId",
                table: "UserQuestions",
                newName: "IX_UserQuestions_UserAvaliationId");

            migrationBuilder.RenameColumn(
                name: "LeaderEvaluationId",
                table: "LeaderQuestions",
                newName: "LeaderAvaliationId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaderQuestions_LeaderEvaluationId",
                table: "LeaderQuestions",
                newName: "IX_LeaderQuestions_LeaderAvaliationId");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartedAt",
                table: "UserAvaliations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartedAt",
                table: "LeaderAvaliations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_LeaderQuestions_LeaderAvaliations_LeaderAvaliationId",
                table: "LeaderQuestions",
                column: "LeaderAvaliationId",
                principalTable: "LeaderAvaliations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuestions_UserAvaliations_UserAvaliationId",
                table: "UserQuestions",
                column: "UserAvaliationId",
                principalTable: "UserAvaliations",
                principalColumn: "Id");
        }
    }
}
