using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using system_SIS.Models;
using system_SIS.Services;

namespace system_SIS.Controllers
{
	public class AccountController : Controller
	{
		private readonly ApplicationDBContext Context;
		private readonly ILogger<AccountController> _logger;

		public AccountController(ILogger<AccountController> logger, ApplicationDBContext context)
		{
			_logger = logger;
			this.Context = context;
		}


		[HttpGet]
		public IActionResult Signin()
		{
			return View();
		}


		[HttpPost]
		public IActionResult Signin(string email, string password)
		{
			var admin = new Account()
			{
				FirstName = "Nadine",
				LastName = "Admin",
				Email = "nadineadmin@gmail.com",
				Password = "Admin123",
				Role = Account.Roles.Admin

			};


			// Check if the email and password match an account in the database
			var account = Context.Account.FirstOrDefault(a => a.Email == email && a.Password == password);
			if (account == null)
			{
				// No account found, return an error or show a message
				ModelState.AddModelError("Email", "Invalid email or password.");
				return View(); // Return the same view to show the error
			}
			else
			{
				return RedirectToAction("SetNewPassword", "Account");
			}
		}


		public IActionResult Signup()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Signup(string firstName, string lastName, string email, string password)
		{
			_logger.LogInformation("FirstName: {0}", firstName);
			//Debug.WriteLine(FirstName); 

			// Check if the email already exists in the database
			var existingAccount = Context.Account.FirstOrDefault(a => a.Email == email);
			if (existingAccount != null)
			{
				// Email already exists, return an error or show a message
				ModelState.AddModelError("Email", "An account with this email already exists.");
				return View(); // Return the same view to show the error
			}

			// If no account exists, create a new one
			var account = new Account()
			{
				FirstName = firstName,
				LastName = lastName,
				Email = email,
				Password = password // Make sure to hash the password before saving
			};

			Context.Account.Add(account);
			Context.SaveChanges();

			return RedirectToAction("Signin", "Account");
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
	}
}
