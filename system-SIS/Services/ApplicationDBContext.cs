using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using system_SIS.Models;

namespace system_SIS.Services
{
    public class ApplicationDBContext(DbContextOptions options) : IdentityDbContext(options)
    {
        // Students in white color is the name of the table in the database (dbSis)
        public DbSet<Students> Students { get; set; }
        public DbSet<StudentAdmission> StudentAdmissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


		// Students in white color is the name of the table in the database (dbSis)
		public DbSet<Faculty_UserProfile> Faculty_UserProfiles { get; set; }   
	}
}
