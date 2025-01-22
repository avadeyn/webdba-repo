using System.ComponentModel.DataAnnotations;

namespace system_SIS.Models
{
    public class Admission_Form
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"[A-Za-z]+", ErrorMessage = "Only letters allowed.")]
        public string FirstName { get; set; } = "";

        [StringLength(50)]
        [RegularExpression(@"[A-Za-z]+", ErrorMessage = "Only letters allowed.")]
        public string MiddleName { get; set; } = "";

        [Required]
        [StringLength(50)]
        [RegularExpression(@"[A-Za-z]+", ErrorMessage = "Only letters allowed.")]
        public string LastName { get; set; } = "";

        [Required]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "LRN must be exactly 12 digits.")]
        [RegularExpression(@"^\d{12}$", ErrorMessage = "LRN must be exactly 12 digits and only integers.")]
        public string LRN { get; set; } = "";

        [Required]
        [Range(64, 100, ErrorMessage = "GWA must be between 64 and 100.")]
        public double GWA { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; } = "";

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(50)]
        public string Religion { get; set; } = "";

        [Required]
        [Range(0, 300)]
        public double Height { get; set; }

        [Required]
        [Range(0, 500)]
        public double Weight { get; set; }

        [Required]
        [StringLength(100)]
        public string PlaceOfBirth { get; set; } = "";

        [Required]
        [EnumDataType(typeof(Sex))]
        public Sex Sex { get; set; }

        [Required]
        [StringLength(50)]
        public string Gender { get; set; } = "";

        [Required]
        [StringLength(50)]
        public string CivilStatus { get; set; } = "";

        [StringLength(50)]
        public string Disability { get; set; } = "";

        [Required]
        [StringLength(50)]
        public string Ethnicity { get; set; } = "";

        [Required]
        [StringLength(50)]
        public string MotherTongue { get; set; } = "";

        // Contact Information
        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number must be exactly 11 digits.")]
        public string Phone { get; set; } = "";

        [Required]
        [StringLength(100)]
        public string CurrentAddress { get; set; } = "";

        [Required]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Zip code must be exactly 4 digits.")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Zip code must be exactly 4 digits.")]
        public string CurrentZipCode { get; set; } = "";

        [Required]
        [StringLength(100)]
        public string PermanentAddress { get; set; } = "";

        [Required]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Zip code must be exactly 4 digits.")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Zip code must be exactly 4 digits.")]
        public string PermanentZipCode { get; set; } = "";

        // Emergency Contact
        [Required]
        [StringLength(50)]
        public string ContactPerson { get; set; } = "";

        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Contact number must be exactly 11 digits.")]
        public string ContactNumber { get; set; } = "";

        [Required]
        [StringLength(50)]
        public string Relationship { get; set; } = "";

        [Required]
        [StringLength(100)]
        public string EmergencyAddress { get; set; } = "";

        // Parent's / Guardian's Information
        [Required]
        [StringLength(50)]
        public string ParentFirstName { get; set; } = "";

        [StringLength(50)]
        public string MaidenName { get; set; } = "";

        [Required]
        [StringLength(50)]
        public string ParentLastName { get; set; } = "";

        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Contact number must be exactly 11 digits.")]
        public string ParentContactNo { get; set; } = "";

        [Required]
        [StringLength(50)]
        public string ParentRelationship { get; set; } = "";

        // Father's Information
        [Required]
        [StringLength(50)]
        public string FatherFirstName { get; set; } = "";

        [StringLength(50)]
        public string FatherMiddleName { get; set; } = "";

        [Required]
        [StringLength(50)]
        public string FatherLastName { get; set; } = "";

        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Contact number must be exactly 11 digits.")]
        public string FatherContactNo { get; set; } = "";

        [Required]
        [StringLength(50)]
        public string FatherRelationship { get; set; } = "";

        // Last School Attended
        [Required]
        [StringLength(100)]
        public string SchoolName { get; set; } = "";

        [Required]
        [StringLength(100)]
        public string SchoolAddress { get; set; } = "";

        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "School contact number must be exactly 11 digits.")]
        public string SchoolContact { get; set; } = "";

        [Required]
        [EnumDataType(typeof(SchoolType))]
        public SchoolType SchoolType { get; set; }

        [Required]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Year of Graduation must be 4 digits.")]
        public string YearOfGraduation { get; set; } = "";
    }

    public enum Sex
    {
        Male,
        Female,
        Other
    }

    public enum SchoolType
    {
        Public,
        Private,
        Other
    }
}

