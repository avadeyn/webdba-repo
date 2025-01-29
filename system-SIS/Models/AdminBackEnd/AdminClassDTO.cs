namespace system_SIS.Models.AdminBackEnd
{
    public class AdminClassDTO
    {
        public int Id { get; set; }
        public required string Section { get; set; }
        public required string Faculty { get; set; }
        public required string Subject { get; set; }
        public required string GradeLevel { get; set; }
        public bool IsDeleted { get; set; }
    }
}