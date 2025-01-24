//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using system_SIS.Models;
//using system_SIS.Services;

//namespace system_SIS.Controllers
//{
	
//	public class AccountController : Controller
//	{
//		//[Authorize(Roles = "Applicant")]

//		private readonly ApplicationDBContext Context;
//		//private readonly ILogger<AccountController> _logger;
//		private readonly UserManager<IdentityUser> _userManager;
//		private readonly SignInManager<IdentityUser> _signInManager;

//		public ApplicationDBContext Context1 => Context;

//		public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApplicationDBContext context)
//		{
//			_userManager = userManager;
//			_signInManager = signInManager;
//			this.Context = context;
//		}


//		[HttpGet]
//		public IActionResult Signin()
//		{
//			return View();
//		}

//        [HttpPost]
//        public async Task<IActionResult> Admin_Logout()
//        {
//            // Sign out the user
//            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

//            // Redirect to login page or any other route
//            return RedirectToAction("Signin", "Account");
//        }

//        [HttpPost]
//		public async Task<IActionResult> Signin(string email, string password)
//		{
//			// Validate if email and password are provided
//			if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
//			{
//				//ModelState.AddModelError(string.Empty, "Email and password are required.");
//				return View();
//			}

//			// Find the user by email
//			var user = await _userManager.FindByEmailAsync(email);

//			if (user == null)
//			{
//				// User not found, return error
//				ModelState.AddModelError(string.Empty, "Invalid login attempt.");
//				return View();
//			}

//			// Check if the user is in a valid role (e.g., "Admin" or "Applicant")
//			var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
//			var isApplicant = await _userManager.IsInRoleAsync(user, "Applicant");
//			var isFaculty = await _userManager.IsInRoleAsync(user, "Faculty");

//			if (!isAdmin && !isApplicant && !isFaculty)
//			{
//				// The user is not in any authorized role
//				ModelState.AddModelError(string.Empty, "You are not authorized.");
//				return View();
//			}

//			// Attempt to sign in the user with the provided password
//			var result = await _signInManager.PasswordSignInAsync(user.UserName, password, isPersistent: false, lockoutOnFailure: false);

//			if (result.Succeeded)
//			{
//				// Redirect based on role
//				if (isAdmin)
//				{
//					return RedirectToAction("Index", "AdminPortal");
//				}
//				else if (isApplicant)
//				{
//					return RedirectToAction("Index", "AdmissionPortal");
//				}
//				else if (isFaculty)
//				{
//					return RedirectToAction("Index", "FacultyPortal");
//				}
//			}

//			// Login failed (e.g., incorrect password)
//			ModelState.AddModelError(string.Empty, "Invalid login attempt.");
//			return View();
//		}


//		public IActionResult Signup()
//		{
//			return View();
//		}

//		[HttpPost]
//		public async Task<IActionResult> Signup(string firstName, string lastName, string email, string password)
//		{
//			// Check if the email already exists
//			var existingUser = await _userManager.FindByEmailAsync(email);
//			if (existingUser != null)
//			{
//				// Email already exists, return an error
//				ModelState.AddModelError("Email", "An account with this email already exists.");
//				return View(); // Return the view to show the error
//			}

//			// Create a new IdentityUser
//			var user = new IdentityUser
//			{
//				UserName = email, // Use email as the username
//				Email = email,
				

//			};

//			// Create the user with the specified password
//			var result = await _userManager.CreateAsync(user, password);

//			if (result.Succeeded)
//			{
//				// Add the user to the "Applicant" role
//				await _userManager.AddToRoleAsync(user, "Applicant");

//				// Save additional user details to your custom Account table
//				var applicantDetails = new Account
//				{
//					//AccountId = user.Id, // Foreign key to AspNetUsers
//					FirstName = firstName,
//					LastName = lastName,
//					Email = email,
//					Password = password
//				};
//				Context1.Account.Add(applicantDetails);
//				await Context1.SaveChangesAsync();

//				// Redirect to the Signin page
//				return RedirectToAction("Signin", "Account");
//			}
//			else
//			{
//				// Add any errors from the Identity result to ModelState
//				foreach (var error in result.Errors)
//				{
//					ModelState.AddModelError(string.Empty, error.Description);
//				}
//				return View();
//			}
//		}




//		public IActionResult ForgotPassword()
//		{
//			return View();
//		}

//		public IActionResult EnterCode()
//		{
//			return View();
//		}

//		public IActionResult SetNewPassword()
//		{
//			return View();
//		}
//	}
//}
