using Microsoft.AspNetCore.Mvc;

namespace system_SIS.Controllers
{
	public class StudentsPortalController : Controller
	{
		public IActionResult Home()
		{
			return View();
		}
        public IActionResult Schedule()
        {
            return View();
        }
        public IActionResult Grades()
        {
            return View();
        }
        public IActionResult Forms()
        {
            return View();
        }
    }
}
