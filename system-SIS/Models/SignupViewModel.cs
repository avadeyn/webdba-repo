using System.ComponentModel.DataAnnotations;

namespace system_SIS.Models
{
	public class SignupViewModel
	{
		[Required(ErrorMessage = "First name is required")]
		[StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
		public required string FirstName { get; set; }

		[Required(ErrorMessage = "Last name is required")]
		[StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
		public required string LastName { get; set; }

		[Required(ErrorMessage = "Email is required.")]
		[EmailAddress(ErrorMessage = "Invalid email address.")]
		public required string Email { get; set; }

		[Required(ErrorMessage = "Password is required.")]
		[StringLength(6, ErrorMessage = "The password must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Compare("ConfirmPassword", ErrorMessage = "The password and confirmation password do not match.")]
		public required string Password { get; set; }

		[Required(ErrorMessage = "Confirm Password is required.")]
		[DataType(DataType.Password)]
		[Display(Name = "Confirm Password")]
		public required string ConfirmPassword { get; set; }
	}
}
