using Microsoft.EntityFrameworkCore.Migrations;

public partial class AddIsDeletedToAdminClass : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<bool>(
            name: "IsDeleted",
            table: "AdminClasses", // Make sure this matches your table name
            type: "bit",
            nullable: false,
            defaultValue: false);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "IsDeleted",
            table: "AdminClasses");
    }
}