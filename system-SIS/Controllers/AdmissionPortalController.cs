using Microsoft.AspNetCore.Mvc;

namespace system_SIS.Controllers
{
	public class AdmissionPortalController : Controller
	{
        public IActionResult Home()
        {
            ViewData["ActiveMenu"] = "Home";
            return View();
        }
        public IActionResult Index()
		{
            ViewData["ActiveMenu"] = "Index";
            return View();
		}

		public IActionResult Contact()
		{
			ViewData["ActiveMenu"] = "Contact";
			return View();

		}

		public IActionResult Family()
		{
			ViewData["ActiveMenu"] = "Family";
			return View();

		}

		public IActionResult School()
		{
			ViewData["ActiveMenu"] = "School";
			return View();

		}

		public IActionResult Document()
		{
			ViewData["ActiveMenu"] = "Document";
			return View();

		}

		public IActionResult Finish()
		{
			ViewData["ActiveMenu"] = "Finish";
			return View();

		}

        public IActionResult Submit_application()
        {
            ViewData["ActiveMenu"] = "Submit_application";
            return View();

        }




    }
}
