using System.ComponentModel.DataAnnotations;

namespace system_SIS.Models
{
    public class Faculty_UserProfile
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50)]
        [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessage = "First name must start with a capital letter and contain only letters.")]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(50)]
        [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessage = "Middle name must start with a capital letter and contain only letters.")]
        public string MiddleName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50)]
        [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessage = "Last name must start with a capital letter and contain only letters.")]
        public string LastName { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Bio cannot exceed 500 characters.")]
        public string Bio { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number must be exactly 11 digits.")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "House number is required.")]
        [Range(1, 99999, ErrorMessage = "House number must be an integer up to 5 digits.")]
        public int HouseNumber { get; set; }

        [Required(ErrorMessage = "Street name is required.")]
        [StringLength(100)]
        [RegularExpression(@"^[A-Z][a-zA-Z\s]*$", ErrorMessage = "Street name must start with a capital letter.")]
        public string StreetName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Barangay is required.")]
        [StringLength(100)]
        [RegularExpression(@"^[A-Z][a-zA-Z\s]*$", ErrorMessage = "Barangay must start with a capital letter.")]
        public string Barangay { get; set; } = string.Empty;

        [Required(ErrorMessage = "City or municipality is required.")]
        [StringLength(100)]
        [RegularExpression(@"^[A-Z][a-zA-Z\s]*$", ErrorMessage = "City or municipality must start with a capital letter.")]
        public string CityOrMunicipality { get; set; } = string.Empty;

        [Required(ErrorMessage = "Province is required.")]
        [StringLength(100)]
        [RegularExpression(@"^[A-Z][a-zA-Z\s]*$", ErrorMessage = "Province must start with a capital letter.")]
        public string Province { get; set; } = string.Empty;

        [Required(ErrorMessage = "Zip code is required.")]
        [Range(1, 9999, ErrorMessage = "Zip code must be an integer up to 4 digits.")]
        public int ZipCode { get; set; }

        public string PhotoPath { get; set; } = string.Empty;
    }

}

