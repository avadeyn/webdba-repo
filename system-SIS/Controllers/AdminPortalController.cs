using Microsoft.AspNetCore.Mvc;

namespace system_SIS.Controllers
{
	public class AdminPortalController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
        public IActionResult Enrollments()
        {
            return View();
        }
        public IActionResult Forms()
        {
            return View();
        }
        public IActionResult Schedule()
        {
            return View();
        }
        public IActionResult Student()
        {
            return View();
        }
        public IActionResult Subject()
        {
            return View();
        }
    }
}
