namespace system_SIS.Models.NewFolder
{
    public class Faculty
    {
        public int Id { get; set; }
        public required string FacultyName { get; set; }
        public required string Email { get; set; }
        public required string ContactNumber { get; set; }
        public required string Status { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string Gender { get; set; }
        public required string Address { get; set; }
        public DateTime DateOfHire { get; set; }
        public required string Position { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
    