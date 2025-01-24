using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace system_SIS.Models
{
    [Table("studentadmissions")]
    public class StudentAdmission
    {
        [Key]
        public int Id { get; set; }

        // Making properties nullable by removing 'required'
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string LRN { get; set; } = string.Empty;
        public decimal GWA { get; set; }
        public string Email { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Religion { get; set; } = string.Empty;
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string PlaceOfBirth { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string CivilStatus { get; set; } = string.Empty;
        public string Disability { get; set; } = string.Empty;
        public string Ethnicity { get; set; } = string.Empty;
        public string MotherTongue { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string CurrentAddress { get; set; } = string.Empty;
        public string CurrentZipCode { get; set; } = string.Empty;
        public string PermanentAddress { get; set; } = string.Empty;
        public string PermanentZipCode { get; set; } = string.Empty;
        public string EmergencyContactPerson { get; set; } = string.Empty;
        public string EmergencyContactNumber { get; set; } = string.Empty;
        public string EmergencyRelationship { get; set; } = string.Empty;
        public string EmergencyAddress { get; set; } = string.Empty;
        public string PrimaryGuardianFirstName { get; set; } = string.Empty;
        public string PrimaryGuardianMaidenName { get; set; } = string.Empty;
        public string PrimaryGuardianLastName { get; set; } = string.Empty;
        public string PrimaryGuardianContactNo { get; set; } = string.Empty;
        public string PrimaryGuardianRelationship { get; set; } = string.Empty;
        public string SecondaryGuardianFirstName { get; set; } = string.Empty;
        public string SecondaryGuardianMiddleName { get; set; } = string.Empty;
        public string SecondaryGuardianLastName { get; set; } = string.Empty;
        public string SecondaryGuardianContactNo { get; set; } = string.Empty;
        public string SecondaryGuardianRelationship { get; set; } = string.Empty;
        public string SchoolName { get; set; } = string.Empty;
        public string SchoolAddress { get; set; } = string.Empty;
        public string SchoolContact { get; set; } = string.Empty;
        public string SchoolType { get; set; } = string.Empty;
        public string YearOfGraduation { get; set; } = string.Empty;
    }
}
