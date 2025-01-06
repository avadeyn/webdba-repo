using Microsoft.EntityFrameworkCore;
using system_SIS.Models;

namespace system_SIS.Services
{
	public class ApplicationDBContext : DbContext
	{
		public ApplicationDBContext(DbContextOptions options) : base(options)
		{

		}

		// Students in white color is the name of the table in the database (dbSis)
		public DbSet<Students> Students { get; set; }
	}
}
