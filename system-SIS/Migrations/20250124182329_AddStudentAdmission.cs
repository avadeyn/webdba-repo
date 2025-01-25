using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace system_SIS.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentAdmission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "studentadmissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeLevel = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LRN = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    GWA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Religion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CivilStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Disability = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ethnicity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MotherTongue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CurrentZipCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    PermanentAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PermanentZipCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmergencyAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ParentFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaidenName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParentLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParentContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentRelationship = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SecondaryGuardianFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SecondaryGuardianMiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SecondaryGuardianLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SecondaryGuardianContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryGuardianRelationship = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SchoolName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SchoolAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SchoolContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolType = table.Column<int>(type: "int", nullable: false),
                    YearOfGraduation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentadmissions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "studentadmissions");
        }
    }
}
