﻿using Microsoft.AspNetCore.Mvc;
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
            ViewData["ActiveMenu"] = "Home";
            return View();
        }
        public IActionResult ListReportCard()
        {
            ViewData["ActiveMenu"] = "Home";
            return View();
        }
        public IActionResult CardGradeReport()
        {
            ViewData["ActiveMenu"] = "Grades";
            return View();
        }

        public IActionResult EncodeGrades()
        {
            ViewData["ActiveMenu"] = "Grades";
            return View();
        }

        public IActionResult ChangeRG()
        {
            ViewData["ActiveMenu"] = "Grades";
            return View();
        }

        public IActionResult RCgrades()
        {
            ViewData["ActiveMenu"] = "Grades";
            return View();
        }

        public IActionResult Profile()
        {
            ViewData["ActiveMenu"] = "Profile";
            return View();
        }
    }
}