using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using system_SIS.Models;
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
                return NotFound();
            }
            return View(profile); // Pass the profile model to the view
        }

        // POST: Edit Profile
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Faculty_UserProfile faculty_userprofile)
        {
            if (id != faculty_userprofile.Id) // Check if the ID matches
            {
                return NotFound();
            }

            if (ModelState.IsValid) // Ensure the model is valid
            {
                try
                {
                    _context.Update(faculty_userprofile); // Update the profile
                    await _context.SaveChangesAsync(); // Save changes to the database
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Faculty_UserProfiles.Any(u => u.Id == faculty_userprofile.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw; // Handle other exceptions   
                    }
                }
                return RedirectToAction(nameof(Index)); // Redirect after successful update
            }

            return View(faculty_userprofile); // Re-render the view if model is invalid
        }
    }
}
