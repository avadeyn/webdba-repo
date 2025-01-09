using Microsoft.AspNetCore.Mvc;

namespace system_SIS.Controllers
{
	public class StudentsPortalController : Controller
	{
		public IActionResult Home()
		{
            ViewData["ActiveMenu"] = "Home";
            return View();
     
		}
        public IActionResult Schedule()
        {
            ViewData["ActiveMenu"] = "Schedule";
            return View();
        }
        public IActionResult Grades()
        {
            ViewData["ActiveMenu"] = "Grades";
            return View();
        }
        public IActionResult Forms()
        {
            ViewData["ActiveMenu"] = "Forms";
            return View();
        }
    }
}
