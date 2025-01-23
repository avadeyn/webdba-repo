using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using system_SIS.Models;

namespace system_SIS.Services
{
	public class ApplicationDBContext : IdentityDbContext
	{
		public ApplicationDBContext(DbContextOptions options) : base(options)
		{

		}

		// Students in white color is the name of the table in the database (dbSis)
		public DbSet<Admission_Form> Admission_Forms { get; set; }
	}
}
