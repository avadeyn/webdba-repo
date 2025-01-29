using System.ComponentModel.DataAnnotations;

namespace system_SIS.Models.AdminBackEnd
{
    public class AdminClass
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Section { get; set; }

        [Required]
        [StringLength(100)]
        public required string Faculty { get; set; }

        [Required]
        [StringLength(100)]
        public required string Subject { get; set; }

        [Required]
        [StringLength(20)]
        public required string GradeLevel { get; set; }

        public bool IsDeleted { get; set; } = false;  
    }
}