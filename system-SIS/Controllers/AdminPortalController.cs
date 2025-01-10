using Microsoft.AspNetCore.Mvc;

namespace system_SIS.Controllers
{
	public class AdminPortalController : Controller
	{
		public IActionResult Index()
		{
            ViewData["ActiveMenu"] = "Index";
            return View();
		}
        public IActionResult Enrollments()
        {
            ViewData["ActiveMenu"] = "Enrollments";
            return View();
        }
        public IActionResult Forms()
        {
            ViewData["ActiveMenu"] = "Forms";
            return View();
        }
        public IActionResult Schedule()
        {
            ViewData["ActiveMenu"] = "Schedule";
            return View();
        }
        public IActionResult Student()
        {
            ViewData["ActiveMenu"] = "Student";
            return View();
        }
        public IActionResult Subject()
        {
            ViewData["ActiveMenu"] = "Subject";
            return View();
        }
    }
}
