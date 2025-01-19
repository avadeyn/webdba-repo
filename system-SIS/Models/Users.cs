using Microsoft.AspNetCore.Identity;


namespace system_SIS.Models
{
	public class Users : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

	}
}
