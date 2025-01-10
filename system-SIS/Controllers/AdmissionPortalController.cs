using Microsoft.AspNetCore.Mvc;

namespace system_SIS.Controllers
{
	public class AdmissionPortalController : Controller
	{
		public IActionResult Index()
		{
            ViewData["ActiveMenu"] = "Index";
            return View();
     
		}
       
        
    }
}
