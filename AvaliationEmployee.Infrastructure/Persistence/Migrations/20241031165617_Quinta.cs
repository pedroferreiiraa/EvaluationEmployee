using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _5W2H.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Quinta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Avaliations_AvaliationId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "AvaliationId",
                table: "Questions",
                newName: "UserAvaliationId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_AvaliationId",
                table: "Questions",
                newName: "IX_Questions_UserAvaliationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Avaliations_UserAvaliationId",
                table: "Questions",
                column: "UserAvaliationId",
                principalTable: "Avaliations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Avaliations_UserAvaliationId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "UserAvaliationId",
                table: "Questions",
                newName: "AvaliationId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_UserAvaliationId",
                table: "Questions",
                newName: "IX_Questions_AvaliationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Avaliations_AvaliationId",
                table: "Questions",
                column: "AvaliationId",
                principalTable: "Avaliations",
                principalColumn: "Id");
        }
    }
}
