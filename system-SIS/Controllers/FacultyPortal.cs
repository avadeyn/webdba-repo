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

        public IActionResult Subject()
        {
            ViewData["ActiveMenu"] = "Subject";
            return View();
        }

        public IActionResult MasterList()
        {
            ViewData["ActiveMenu"] = "MasterList";
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

        public IActionResult ViewClassAd()
        {
            ViewData["ActiveMenu"] = "ViewClassAd";
            return View();
        }
        public IActionResult ListReportCard()
        {
            ViewData["ActiveMenu"] = "ListReportCard";
            return View();
        }

    }
}

