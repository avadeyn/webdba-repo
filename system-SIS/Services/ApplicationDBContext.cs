using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using system_SIS.Models;
using system_SIS.Models.NewFolder;
using system_SIS.Models.AdminBackEnd;

namespace system_SIS.Services
{
    public class ApplicationDBContext(DbContextOptions options) : IdentityDbContext(options)
    {
        public DbSet<Students> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set; }

		    public DbSet<Account> Account { get; set; }
        public DbSet<Announcements> Announcements { get; set; }
        public DbSet<AdminClass> AdminClasses { get; set; }
        public DbSet<AdminSchedule> AdminSchedules { get; set; }


        public DbSet<Account> Account { get; set; }
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
