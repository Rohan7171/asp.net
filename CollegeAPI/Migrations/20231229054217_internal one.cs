using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeAPI.Migrations
{
    /// <inheritdoc />
    public partial class internalone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientType",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "bednum",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "diagnosis",
                table: "Students",
                newName: "university");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "university",
                table: "Students",
                newName: "diagnosis");

            migrationBuilder.AddColumn<string>(
                name: "PatientType",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "bednum",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
