using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _5W2H.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class leader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaderAvaliations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EvaluatorId = table.Column<int>(type: "int", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaderAvaliations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeaderQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeaderAvaliationId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaderQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaderQuestions_LeaderAvaliations_LeaderAvaliationId",
                        column: x => x.LeaderAvaliationId,
                        principalTable: "LeaderAvaliations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LeaderAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvaliationId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    AnswerNumber = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaderAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaderAnswers_LeaderAvaliations_AvaliationId",
                        column: x => x.AvaliationId,
                        principalTable: "LeaderAvaliations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaderAnswers_LeaderQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "LeaderQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaderAnswers_AvaliationId_QuestionId",
                table: "LeaderAnswers",
                columns: new[] { "AvaliationId", "QuestionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LeaderAnswers_QuestionId",
                table: "LeaderAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaderQuestions_LeaderAvaliationId",
                table: "LeaderQuestions",
                column: "LeaderAvaliationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaderAnswers");

            migrationBuilder.DropTable(
                name: "LeaderQuestions");

            migrationBuilder.DropTable(
                name: "LeaderAvaliations");
        }
    }
}
