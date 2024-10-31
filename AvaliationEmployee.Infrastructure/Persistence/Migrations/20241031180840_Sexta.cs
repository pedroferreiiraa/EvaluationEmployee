using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _5W2H.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Sexta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedAt",
                table: "Avaliations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EvaluatorId",
                table: "Avaliations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartedAt",
                table: "Avaliations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedAt",
                table: "Avaliations");

            migrationBuilder.DropColumn(
                name: "EvaluatorId",
                table: "Avaliations");

            migrationBuilder.DropColumn(
                name: "StartedAt",
                table: "Avaliations");
        }
    }
}
