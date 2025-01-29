using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace system_SIS.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedToSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AdminSchedules",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AdminSchedules");
        }
    }
}
