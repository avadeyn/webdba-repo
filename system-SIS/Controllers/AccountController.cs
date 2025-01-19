using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using system_SIS.Models;

namespace system_SIS.Controllers
{
	public class AccountController : Controller
	{
		private readonly SignInManager<Users> signInManager;
		private readonly UserManager<Users> userManager;

		public AccountController(SignInManager<Users> signInManager, UserManager<Users> userManager)
		{
			this.signInManager = signInManager;
			this.userManager = userManager;
		}

		public IActionResult Signin()
		{
			return View();
		}

		public IActionResult Signup()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Signup(SignupViewModel model)
		{
			if (ModelState.IsValid)
			{
				Users users = new Users
				{
					FirstName = model.FirstName,
					LastName = model.LastName,
					Email = model.Email,


				};

				var result = await userManager.CreateAsync(users, model.Password);

				if (result.Succeeded)
				{
					await signInManager.SignInAsync(users, isPersistent: false);
					return RedirectToAction("Signin", "Account");

				}
				else
				{
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}

					return View(model);

				}
			}
			return View(model);
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
