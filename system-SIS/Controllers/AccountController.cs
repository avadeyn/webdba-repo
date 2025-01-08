using Microsoft.AspNetCore.Mvc;

namespace system_SIS.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Signin()
		{
			return View();
		}

		public IActionResult Signup()
		{
			return View();
		}

		public IActionResult ForgotPassword()
		{
			return View();
		}
	}
}
