using Microsoft.AspNetCore.Mvc;
using system_SIS.Models;
using system_SIS.Extensions;
using system_SIS.Services;
using Microsoft.Extensions.Logging;

namespace system_SIS.Controllers
{
    public class AdmissionPortalController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<AdmissionPortalController> _logger;

        public AdmissionPortalController(ApplicationDBContext context, ILogger<AdmissionPortalController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Start()
        {
           var model = new StudentAdmission();
    return View(model);
        }

        [HttpPost]
        public IActionResult Start(StudentAdmission model)
        {
            if (ModelState.IsValid)
            {
                var existingData = HttpContext.Session.GetObject<StudentAdmission>("AdmissionData") ?? new StudentAdmission();

                // Update personal information properties
                existingData.GradeLevel = model.GradeLevel;

                HttpContext.Session.SetObject("AdmissionData", existingData);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public IActionResult Index()
        {
            ViewData["ActiveMenu"] = "Index";
            var model = HttpContext.Session.GetObject<StudentAdmission>("AdmissionData") ?? new StudentAdmission();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(StudentAdmission model)
        {
            if (ModelState.IsValid)
            {
                var existingData = HttpContext.Session.GetObject<StudentAdmission>("AdmissionData") ?? new StudentAdmission();

                // Update personal information properties
                existingData.FirstName = model.FirstName;
                existingData.MiddleName = model.MiddleName;
                existingData.LastName = model.LastName;
                existingData.LRN = model.LRN;
                existingData.GWA = model.GWA;
                existingData.Email = model.Email;
                existingData.DateOfBirth = model.DateOfBirth;
                existingData.Religion = model.Religion;
                existingData.Height = model.Height;
                existingData.Weight = model.Weight;
                existingData.PlaceOfBirth = model.PlaceOfBirth;
                existingData.Gender = model.Gender;
                existingData.CivilStatus = model.CivilStatus;
                existingData.Disability = model.Disability;
                existingData.Ethnicity = model.Ethnicity;
                existingData.MotherTongue = model.MotherTongue;

                HttpContext.Session.SetObject("AdmissionData", existingData);
                return RedirectToAction("Contact");
            }
            return View(model);
        }

        public IActionResult Contact()
        {
            ViewData["ActiveMenu"] = "Contact";
            var model = HttpContext.Session.GetObject<StudentAdmission>("AdmissionData") ?? new StudentAdmission();
            return View(model);
        }

        [HttpPost]
        public IActionResult Contact(StudentAdmission model)
        {
            if (ModelState.IsValid)
            {
                var existingData = HttpContext.Session.GetObject<StudentAdmission>("AdmissionData") ?? new StudentAdmission();

                // Update contact information
                existingData.Phone = model.Phone;
                existingData.CurrentAddress = model.CurrentAddress;
                existingData.CurrentZipCode = model.CurrentZipCode;
                existingData.PermanentAddress = model.PermanentAddress;
                existingData.PermanentZipCode = model.PermanentZipCode;
                existingData.ContactPerson = model.ContactPerson;
                existingData.ContactNumber = model.ContactNumber;
                existingData.Relationship = model.Relationship;
                existingData.EmergencyAddress = model.EmergencyAddress;

                HttpContext.Session.SetObject("AdmissionData", existingData);
                return RedirectToAction("Family");
            }
            return View(model);
        }

        public IActionResult Family()
        {
            ViewData["ActiveMenu"] = "Family";
            var model = HttpContext.Session.GetObject<StudentAdmission>("AdmissionData") ?? new StudentAdmission();
            return View(model);
        }

        [HttpPost]
        public IActionResult Family(StudentAdmission model)
        {
            if (ModelState.IsValid)
            {
                var existingData = HttpContext.Session.GetObject<StudentAdmission>("AdmissionData") ?? new StudentAdmission();

                // Update family information
                existingData.ParentFirstName = model.FirstName;
                existingData.MaidenName = model.MaidenName;
                existingData.ParentLastName = model.ParentLastName;
                existingData.ParentContactNo = model.ParentContactNo;
                existingData.ParentRelationship = model.ParentRelationship;
                existingData.SecondaryGuardianFirstName = model.SecondaryGuardianFirstName;
                existingData.SecondaryGuardianMiddleName = model.SecondaryGuardianMiddleName;
                existingData.SecondaryGuardianLastName = model.SecondaryGuardianLastName;
                existingData.SecondaryGuardianContactNo = model.SecondaryGuardianContactNo;
                existingData.SecondaryGuardianRelationship = model.SecondaryGuardianRelationship;

                HttpContext.Session.SetObject("AdmissionData", existingData);
                return RedirectToAction("School");
            }
            return View(model);
        }

        public IActionResult School()
        {
            ViewData["ActiveMenu"] = "School";
            var model = HttpContext.Session.GetObject<StudentAdmission>("AdmissionData") ?? new StudentAdmission();
            return View(model);
        }

        [HttpPost]
        public IActionResult School(StudentAdmission model)
        {
            if (ModelState.IsValid)
            {
                var existingData = HttpContext.Session.GetObject<StudentAdmission>("AdmissionData") ?? new StudentAdmission();

                // Update school information
                existingData.SchoolName = model.SchoolName;
                existingData.SchoolAddress = model.SchoolAddress;
                existingData.SchoolContact = model.SchoolContact;
                existingData.SchoolType = model.SchoolType;
                existingData.YearOfGraduation = model.YearOfGraduation;

                HttpContext.Session.SetObject("AdmissionData", existingData);
                return RedirectToAction("Document");
            }
            return View(model);
        }

        public IActionResult Document()
        {
            ViewData["ActiveMenu"] = "Document";
            var model = HttpContext.Session.GetObject<StudentAdmission>("AdmissionData");
            if (model == null)
            {
                _logger.LogWarning("No admission data found in session at Document page");
                return RedirectToAction("Finish");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Document(StudentAdmission model, List<IFormFile> documents)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingData = HttpContext.Session.GetObject<StudentAdmission>("AdmissionData");
                    if (existingData == null)
                    {
                        _logger.LogWarning("No existing data found in session during Document submission");
                        return RedirectToAction("Document");
                    }

                    if (documents != null && documents.Count > 0)
                    {
                        foreach (var document in documents)
                        {
                            if (document.Length > 5 * 1024 * 1024)
                            {
                                ModelState.AddModelError("", "File size must not exceed 5MB");
                                return View(model);
                            }

                            var allowedExtensions = new[] { ".pdf", ".docx", ".png", ".jpeg", ".jpg" };
                            var extension = Path.GetExtension(document.FileName).ToLowerInvariant();
                            if (!allowedExtensions.Contains(extension))
                            {
                                ModelState.AddModelError("", "Invalid file type. Only PDF, DOCX, PNG, JPEG, and JPG files are allowed.");
                                return View(model);
                            }

                            // Process the file asynchronously
                            using var memoryStream = new MemoryStream();
                            await document.CopyToAsync(memoryStream);

                            // Here you would typically save the file to your storage (e.g., a folder or cloud storage)
                            _logger.LogInformation("Processed document: {FileName}, Size: {FileSize} bytes", document.FileName, document.Length);
                        }
                    }

                    // Save data and proceed
                    HttpContext.Session.SetObject("AdmissionData", existingData);
                    _logger.LogInformation("Document step completed successfully");
                    return RedirectToAction("Finish");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error processing document submission");
                    ModelState.AddModelError("", "An error occurred while processing your documents. Please try again.");
                    return View(model);
                }
            }

            return View(model);
        }


        public IActionResult Finish()
        {
            ViewData["ActiveMenu"] = "Finish";
            var model = HttpContext.Session.GetObject<StudentAdmission>("AdmissionData");

            if (model == null)
            {
                _logger.LogWarning("No admission data found in session when reaching Finish page");
                return RedirectToAction("Index");
            }

            _logger.LogInformation("Retrieved admission data for Finish page: {@Model}", model);
            return View(model);
        }

        [HttpPost]
        public IActionResult Submit_application()
        {
            var admissionData = HttpContext.Session.GetObject<StudentAdmission>("AdmissionData");
            if (admissionData != null)
            {
                try
                {
                    _context.StudentAdmissions.Add(admissionData);
                    _context.SaveChanges();

                    HttpContext.Session.Remove("AdmissionData");

                    TempData["SuccessMessage"] = "Application submitted successfully!";
                    return RedirectToAction("SubmissionSuccess");
                }
                catch (Exception exception)
                {
                    _logger.LogError(exception, "Error occurred while submitting application");
                    ModelState.AddModelError("", "An error occurred while submitting your application. Please try again.");
                    return RedirectToAction("Finish");
                }
            }

            ModelState.AddModelError("", "No application data found. Please fill out the form.");
            return RedirectToAction("SubmissionSuccess");
        }

        public IActionResult SubmissionSuccess()
        {
            ViewData["ActiveMenu"] = "Success";
            return View();
        }
    }
}