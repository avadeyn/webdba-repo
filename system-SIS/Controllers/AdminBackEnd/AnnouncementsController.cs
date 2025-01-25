using Microsoft.AspNetCore.Mvc;
using system_SIS.Models.AdminBackEnd;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using system_SIS.Services;

namespace system_SIS.Controllers.AdminBackEnd
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public AnnouncementsController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var announcements = await _context.Announcements
                .OrderByDescending(a => a.CreatedAt)
                .ToListAsync();
            return Ok(announcements);
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Announcements announcement)
        {
            if (ModelState.IsValid)
            {
                announcement.CreatedAt = DateTime.UtcNow;
                _context.Announcements.Add(announcement);
                await _context.SaveChangesAsync();
                // Instead of returning Ok, redirect back
                return RedirectToAction("Index", "AdminPortal");
            }
            return BadRequest(ModelState);
        }
    }
}
            