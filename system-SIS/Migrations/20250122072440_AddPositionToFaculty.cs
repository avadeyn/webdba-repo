using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace system_SIS.Migrations
{
    /// <inheritdoc />
    public partial class AddPositionToFaculty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Faculties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Faculties");
        }
    }
}
