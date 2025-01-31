using Microsoft.AspNetCore.Mvc;
using system_SIS.Models.AdminBackEnd;
using system_SIS.Services.AdminBackEnd;

namespace system_SIS.Controllers.AdminBackEnd
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacultyController(IFacultyService facultyService) : ControllerBase
    {
        private readonly IFacultyService _facultyService = facultyService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Faculty>>> GetAllFaculty()
        {
            try
            {
                var faculties = await _facultyService.GetAllFacultyAsync();
                return Ok(faculties);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Faculty>> GetFacultyById(int id)
        {
            try
            {
                var faculty = await _facultyService.GetFacultyByIdAsync(id);
                return Ok(faculty);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Faculty>> AddFaculty([FromBody] Faculty faculty)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _facultyService.AddFacultyAsync(faculty);
                return CreatedAtAction(nameof(GetFacultyById), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Faculty>> UpdateFaculty(int id, [FromBody] Faculty faculty)
        {
            try
            {
                if (id != faculty.Id)
                {
                    return BadRequest("ID mismatch");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _facultyService.UpdateFacultyAsync(faculty);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFaculty(int id)
        {
            try
            {
                await _facultyService.SoftDeleteFacultyAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Optional: Additional endpoints for managing deleted records
        [HttpGet("deleted")]
        public async Task<ActionResult<IEnumerable<Faculty>>> GetDeletedFaculty()
        {
            try
            {
                var deletedFaculties = await _facultyService.GetDeletedFacultyAsync();
                return Ok(deletedFaculties);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("{id}/restore")]
        public async Task<IActionResult> RestoreFaculty(int id)
        {
            try
            {
                await _facultyService.RestoreFacultyAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}