using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using system_SIS.Models;
using system_SIS.Models.NewFolder;  // Add this line

namespace system_SIS.Services
{
    public class ApplicationDBContext(DbContextOptions options) : IdentityDbContext(options)
    {
        public DbSet<Students> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
    }
  
        public DbSet<Students> Students { get; set; }
        public DbSet<Account> Account { get; set; }

}
