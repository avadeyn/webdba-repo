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

        public IActionResult Grade8()
        {
            ViewData["ActiveMenu"] = "Grade8";
            return View();
        }

        public IActionResult Grade9()
        {
            ViewData["ActiveMenu"] = "Grade9";
            return View();
        }

        public IActionResult Grade10()
        {
            ViewData["ActiveMenu"] = "Grade10";
            return View();
        }
        public IActionResult Studentlist7()
        {
            ViewData["ActiveMenu"] = "Studentlist7";
            return View();
        }
        public IActionResult Studentlist8()
        {
            ViewData["ActiveMenu"] = "Studentlist8";
            return View();
        }
        public IActionResult Studentlist9()
        {
            ViewData["ActiveMenu"] = "Studentlist9";
            return View();
        }
        public IActionResult Studentlist10()
        {
            ViewData["ActiveMenu"] = "Studentlist10";
            return View();
        }
        public IActionResult StudentDetail()
        {
            ViewData["ActiveMenu"] = "StudentDetail";
            return View();
        }
    }
}
