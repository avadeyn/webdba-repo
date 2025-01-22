using System.ComponentModel.DataAnnotations;

namespace system_SIS.Models
{
	public class Account
	{
		public enum Roles
		{
			Admin = 1,
			Faculty = 2,
			Student = 3,
			Applicant = 4
		}

		public Roles Role { get; set; }

		[Key]
		public int AccountId { get; set; }

		[Required(ErrorMessage = "First name is required")]
		[StringLength(30, ErrorMessage = "First name cannot exceed 50 characters")]
		public required string FirstName { get; set; }

		[Required(ErrorMessage = "Last name is required")]
		[StringLength(20, ErrorMessage = "Last name cannot exceed 50 characters")]
		public required string LastName { get; set; }

		[Required(ErrorMessage = "Email is required.")]
		[EmailAddress(ErrorMessage = "Invalid email address.")]
		public required string Email { get; set; }

		[Required(ErrorMessage = "Password is required.")]
		[StringLength(20, MinimumLength = 6, ErrorMessage = "The password must be at least {2} and at max {1} characters long.")]
		[DataType(DataType.Password)]
		public required string Password { get; set; }
	}
}
