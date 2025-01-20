using Microsoft.AspNetCore.Identity;

namespace system_SIS.Controllers
{
	public class User : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

	}
}
