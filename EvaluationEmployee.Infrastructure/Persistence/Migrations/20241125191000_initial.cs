using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _5W2H.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
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
                    LeaderId = table.Column<int>(type: "int", nullable: false),
                    EvaluatorId = table.Column<int>(type: "int", nullable: false),
                    DateReference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImprovePoints = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Goals = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SixMonthAlignment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaderAvaliations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAvaliations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EvaluatorId = table.Column<int>(type: "int", nullable: false),
                    DateReference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImprovePoints = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Goals = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SixMonthAlignment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAvaliations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeaderQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeaderEvaluationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaderQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaderQuestions_LeaderAvaliations_LeaderEvaluationId",
                        column: x => x.LeaderEvaluationId,
                        principalTable: "LeaderAvaliations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEvaluationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserQuestions_UserAvaliations_UserEvaluationId",
                        column: x => x.UserEvaluationId,
                        principalTable: "UserAvaliations",
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

            migrationBuilder.CreateTable(
                name: "UserAnswers",
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
                    table.PrimaryKey("PK_UserAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAnswers_UserAvaliations_AvaliationId",
                        column: x => x.AvaliationId,
                        principalTable: "UserAvaliations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAnswers_UserQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "UserQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LiderId = table.Column<int>(type: "int", nullable: false),
                    GestorId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeMo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodFuncionario = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_GestorId",
                table: "Departments",
                column: "GestorId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_LiderId",
                table: "Departments",
                column: "LiderId");

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
                name: "IX_LeaderQuestions_LeaderEvaluationId",
                table: "LeaderQuestions",
                column: "LeaderEvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_AvaliationId_QuestionId",
                table: "UserAnswers",
                columns: new[] { "AvaliationId", "QuestionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_QuestionId",
                table: "UserAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuestions_UserEvaluationId",
                table: "UserQuestions",
                column: "UserEvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId",
                table: "Users",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_GestorId",
                table: "Departments",
                column: "GestorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_LiderId",
                table: "Departments",
                column: "LiderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_GestorId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_LiderId",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "LeaderAnswers");

            migrationBuilder.DropTable(
                name: "UserAnswers");

            migrationBuilder.DropTable(
                name: "LeaderQuestions");

            migrationBuilder.DropTable(
                name: "UserQuestions");

            migrationBuilder.DropTable(
                name: "LeaderAvaliations");

            migrationBuilder.DropTable(
                name: "UserAvaliations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
