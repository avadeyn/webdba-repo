using SixLabors.ImageSharp;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Web.Http;
using Twilio.Types;

namespace system_SIS.Models
{
	public class Account
	{

		[Key]
		//public int AccountId { get; set; }

		[Required(ErrorMessage = "First name is required")]
		[StringLength(30, ErrorMessage = "First name cannot exceed 50 characters")]
		public required string FirstName { get; set; }

		[Required(ErrorMessage = "Last name is required")]
		[StringLength(20, ErrorMessage = "Last name cannot exceed 50 characters")]
		public required string LastName { get; set; }

		[Required(ErrorMessage = "Email is required.")]
		[EmailAddress(ErrorMessage = "Invalid email address.")]
		public required string Email { get; set; }

		[Required(ErrorMessage = "Phone number is required.")]
		[Phone(ErrorMessage = "Invalid phone number.")]
		public required string PhoneNumber { get; set; }

		[Required(ErrorMessage = "Password is required.")]
		[StringLength(20, MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Compare("ConfirmPassword", ErrorMessage ="Passwprds don't match.")]
		public required string Password { get; set; }

		[Required(ErrorMessage = "Confirm Password is required.")]
		[DataType(DataType.Password)]
		public required string ConfirmPassword { get; set; }
	}

}
