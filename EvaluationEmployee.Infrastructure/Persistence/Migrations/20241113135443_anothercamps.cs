using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _5W2H.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class anothercamps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Goals",
                table: "UserAvaliations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImprovePoints",
                table: "UserAvaliations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pdi",
                table: "UserAvaliations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SixMonthAlignment",
                table: "UserAvaliations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Goals",
                table: "LeaderAvaliations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImprovePoints",
                table: "LeaderAvaliations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pdi",
                table: "LeaderAvaliations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SixMonthAlignment",
                table: "LeaderAvaliations",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Goals",
                table: "UserAvaliations");

            migrationBuilder.DropColumn(
                name: "ImprovePoints",
                table: "UserAvaliations");

            migrationBuilder.DropColumn(
                name: "Pdi",
                table: "UserAvaliations");

            migrationBuilder.DropColumn(
                name: "SixMonthAlignment",
                table: "UserAvaliations");

            migrationBuilder.DropColumn(
                name: "Goals",
                table: "LeaderAvaliations");

            migrationBuilder.DropColumn(
                name: "ImprovePoints",
                table: "LeaderAvaliations");

            migrationBuilder.DropColumn(
                name: "Pdi",
                table: "LeaderAvaliations");

            migrationBuilder.DropColumn(
                name: "SixMonthAlignment",
                table: "LeaderAvaliations");
        }
    }
}
