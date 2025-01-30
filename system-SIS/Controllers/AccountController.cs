using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using system_SIS.Models;
using system_SIS.Services;
//using Twilio.Types;
//using Twilio.Rest.Api.V2010.Account;
//using Twilio.Rest.Verify.V2.Service;
//using Twilio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace system_SIS.Controllers
{

	public class AccountController : Controller
	{
		//[Authorize(Roles = "Applicant")]

		private readonly ApplicationDBContext Context;
		//private readonly ILogger<AccountController> _logger;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;

		public ApplicationDBContext Context1 => Context;

		public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApplicationDBContext context)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			this.Context = context;
		}


		[HttpGet]
		public IActionResult Signin()
		{
			return View();
		}

		[HttpPost] // not working
		public async Task<IActionResult> Admin_Logout()
		{
			// Sign out the user
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

			// Redirect to login page or any other route
			return RedirectToAction("Signin", "Account");
		}

		[HttpPost]
		public async Task<IActionResult> Signin(string email, string password)
		{
			// Validate if email and password are provided
			if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
			{
				ViewData["Email"] = email; // Retain entered email
				ViewData["Password"] = password;
				//ViewData["Error"] = "Email and password are required.";
				return View();
			}
			// Find the user by email
			var user = await _userManager.FindByEmailAsync(email);

			if (user == null)
			{
				// User not found, return error
				ViewData["Email"] = email; // Retain entered email
				ViewData["Password"] = password; // Retain entered password
				ModelState.AddModelError(string.Empty, "Invalid login attempt.");
				return View();
			}

			// Check if the user is in a valid role (e.g., "Admin" or "Applicant")
			var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
			var isApplicant = await _userManager.IsInRoleAsync(user, "Applicant");
			var isFaculty = await _userManager.IsInRoleAsync(user, "Faculty");

			if (!isAdmin && !isApplicant && !isFaculty)
			{
				// The user is not in any authorized role
				ViewData["Email"] = email; // Retain entered email
				ViewData["Password"] = password; 
				ModelState.AddModelError(string.Empty, "You are not authorized.");
				return View();
			}

			// Attempt to sign in the user with the provided password
			var result = await _signInManager.PasswordSignInAsync(user.Email, password, isPersistent: false, lockoutOnFailure: false);

			if (result.Succeeded)
			{
				// Redirect based on role
				if (isAdmin)
				{
					return RedirectToAction("Index", "AdminPortal");
				}
				else if (isApplicant)
				{
					return RedirectToAction("Start", "AdmissionPortal");
				}
				else if (isFaculty)
				{
					return RedirectToAction("Index", "FacultyPortal");
				}
			}

			// Login failed (e.g., incorrect password)
			ViewData["Email"] = email; // Retain entered email
			ViewData["Password"] = password;
			ModelState.AddModelError(string.Empty, "Invalid login attempt.");
			return View();
		}


		public IActionResult Signup()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Signup(string firstName, string lastName, string email, string password, string confirmPassword, string phoneNumber)
		{
			// Check if any of the fields are null or empty
			if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
			{
				ModelState.AddModelError(string.Empty, "All fields are required.");

				// Use ViewData to retain the values entered by the user in case of error
				ViewData["FirstName"] = firstName;
				ViewData["LastName"] = lastName;
				ViewData["Email"] = email;
				ViewData["PhoneNumber"] = phoneNumber;

				return View(); // Return the view to show the error and reload the form
			}

			// Check if the password and confirm password match
			if (password != confirmPassword)
			{
				ModelState.AddModelError("ConfirmPassword", "Passwords do not match.");

				// Retain the values entered by the user
				ViewData["FirstName"] = firstName;
				ViewData["LastName"] = lastName;
				ViewData["Email"] = email;
				ViewData["PhoneNumber"] = phoneNumber;

				return View(); // Return the view with the error
			}

			// Check if the email already exists
			var existingUser = await _userManager.FindByEmailAsync(email);
			if (existingUser != null)
			{
				ModelState.AddModelError("Email", "An account with this email already exists.");

				// Retain the values entered by the user in case of error
				ViewData["FirstName"] = firstName;
				ViewData["LastName"] = lastName;
				ViewData["Email"] = email;
				ViewData["PhoneNumber"] = phoneNumber;

				return View(); // Return the view to show the error and reload the form
			}

			// Create a new IdentityUser
			var user = new IdentityUser
			{
				UserName = email, // Use email as the username
				Email = email,
				PhoneNumber = phoneNumber,
			};

			// Create the user with the specified password
			var result = await _userManager.CreateAsync(user, password);

			if (result.Succeeded)
			{
				// Add the user to the "Applicant" role
				await _userManager.AddToRoleAsync(user, "Applicant");

				//return SendOTP(phoneNumber);
				return RedirectToAction("Signin", "Account");
			}
			else
			{
				// Add any errors from the Identity result to ModelState
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}

				// Retain the form values in case of an error
				ViewData["FirstName"] = firstName;
				ViewData["LastName"] = lastName;
				ViewData["Email"] = email;
				ViewData["PhoneNumber"] = phoneNumber;

				return View();
			}
		}




		public IActionResult ForgotPassword()
		{
			

			return View();
		}


		
		public IActionResult EnterCode()
		{

			return View();
		}

		public IActionResult SetNewPassword()
		{
			return View();
		}

		//[HttpPost]
		//public IActionResult SendOTP(string phoneNumber)
		//{
		//	var number = phoneNumber.Substring(1);
		//	var finalNumber = "+63" + number;


		//	var accountSid = "ACf318bccd2b7b397279659c101a85ef4a";
		//	var authToken = "618114b49848bc577cad4ed26bd9953f";
		//	TwilioClient.Init(accountSid, authToken);

		//	var verification = VerificationResource.Create(
		//		to: finalNumber,
		//		channel: "sms",
		//		pathServiceSid: "VA03960829216dedab8d7ae3e4794fdf74"
		//	);

		//	return RedirectToAction("EnterCode", "Account");

		//}
	}
}
