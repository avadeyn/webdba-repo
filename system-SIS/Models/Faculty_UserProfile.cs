using System.ComponentModel.DataAnnotations;

namespace system_SIS.Models
{
    public class Faculty_UserProfile
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = "";   

        [StringLength(50)]
        public string MiddleName { get; set; } = "";

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = "";

        [Phone]
        public string PhoneNumber { get; set; } = "";

        [Required]
        public DateTime DateOfBirth { get; set; }

        [StringLength(500)]
        public string Bio { get; set; } = "";
    }
}
