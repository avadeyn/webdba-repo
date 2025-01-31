using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using system_SIS.Models;
using system_SIS.Models.AdminBackEnd;

namespace system_SIS.Services
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        // Student related tables
        public DbSet<Students> Students { get; set; }
        public DbSet<StudentAdmission> StudentAdmissions { get; set; }

        // Faculty related tables
        public DbSet<Faculty> Faculties { get; set; }

        // Admin related tables
        public DbSet<AdminClass> AdminClasses { get; set; }
        public DbSet<AdminSchedule> AdminSchedules { get; set; }

        // Other tables
        public DbSet<Account> Account { get; set; }
        public DbSet<Announcements> Announcements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure StudentAdmission entity
            modelBuilder.Entity<StudentAdmission>(entity =>
            {
                entity.Property(e => e.GWA).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Height).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Weight).HasColumnType("decimal(18,2)");
            });

            // Add soft delete query filters
            modelBuilder.Entity<AdminClass>()
                .HasQueryFilter(m => !m.IsDeleted);

            modelBuilder.Entity<AdminSchedule>()
                .HasQueryFilter(m => !m.IsDeleted);
        }
    }
}