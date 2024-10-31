using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _5W2H.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvaliadorId",
                table: "Avaliations");

            migrationBuilder.AddColumn<int>(
                name: "AvaliationId",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_AvaliationId",
                table: "Questions",
                column: "AvaliationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Avaliations_AvaliationId",
                table: "Questions",
                column: "AvaliationId",
                principalTable: "Avaliations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Avaliations_AvaliationId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_AvaliationId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "AvaliationId",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "AvaliadorId",
                table: "Avaliations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
