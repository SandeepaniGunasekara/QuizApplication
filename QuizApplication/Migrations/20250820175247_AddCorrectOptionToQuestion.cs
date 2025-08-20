using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddCorrectOptionToQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoorectOption",
                table: "Questions",
                newName: "CorrectOption");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CorrectOption",
                table: "Questions",
                newName: "CoorectOption");
        }
    }
}
