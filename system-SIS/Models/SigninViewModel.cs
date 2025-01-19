using System.ComponentModel.DataAnnotations;

namespace system_SIS.Models
{
	public class SigninViewModel
	{
		[Required(ErrorMessage = "Email is required.")]
		[EmailAddress(ErrorMessage = "Invalid email address.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Password is required.")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
