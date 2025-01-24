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

            modelBuilder.Entity<StudentAdmission>(entity =>
            {
                entity.Property(e => e.GWA).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Height).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Weight).HasColumnType("decimal(18,2)");
            });
        }
    }
}