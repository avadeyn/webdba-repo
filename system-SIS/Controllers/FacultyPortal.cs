using Microsoft.AspNetCore.Mvc;

namespace system_SIS.Controllers
{
    public class FacultyPortalController : Controller
    {
        public IActionResult Index()
        {
            ViewData["ActiveMenu"] = "Home";
            return View();
        }

        public IActionResult Student()
        {
            ViewData["ActiveMenu"] = "Student";
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
