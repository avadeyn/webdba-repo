using System;
using System.ComponentModel.DataAnnotations;

namespace system_SIS.Models.AdminBackEnd
{
    public class Announcements
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Header { get; set; }

        [Required]
        public required string Details { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
