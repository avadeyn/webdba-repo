using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using system_SIS.Models;
using System.Linq;
using System.Threading.Tasks;
using system_SIS.Services;

namespace system_SIS.Controllers
{
    public class Faculty_UserProfileController : Controller
    {
        private readonly ApplicationDBContext _context;

        public Faculty_UserProfileController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Render Edit View
        public IActionResult Edit(int id)
        {
            var profile = _context.Faculty_UserProfiles.FirstOrDefault(u => u.Id == id);
            if (profile == null)
            {
                return NotFound(); // If profile not found, return NotFound
            }
            return View(profile); // Pass the profile model to the view for editing
        }

        // POST: Edit Profile
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Faculty_UserProfile faculty_userprofile)
        {
            if (id != faculty_userprofile.Id) // Ensure the IDs match for validation
            {
                return NotFound(); // If ID mismatch, return NotFound
            }

            if (ModelState.IsValid) // Ensure the model passed from the form is valid
            {
                try
                {
                    _context.Update(faculty_userprofile); // Update the user profile in the database
                    await _context.SaveChangesAsync(); // Save the changes to the database
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Handle concurrency exceptions by checking if the entity exists in the database
                    if (!_context.Faculty_UserProfiles.Any(u => u.Id == faculty_userprofile.Id))
                    {
                        return NotFound(); // If entity does not exist, return NotFound
                    }
                    else
                    {
                        throw; // Throw other exceptions that occur
                    }
                }
                return RedirectToAction(nameof(Index)); // Redirect back to the index page after successful update
            }

            return View(faculty_userprofile); // If model is invalid, return the same view with the model to correct the errors
        }
    }
}
