using Microsoft.AspNetCore.Mvc;

namespace system_SIS.Controllers
{
	public class StudentsPortalController : Controller
	{
		public IActionResult Home()
		{
			return View();
		}
	}
}
