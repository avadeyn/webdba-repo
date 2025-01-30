using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using system_SIS.Models.AdminBackEnd;
using system_SIS.Services.AdminBackEnd;

namespace system_SIS.Controllers.AdminBackEnd
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminClassController(
        IAdminClassService classService,
        ILogger<AdminClassController> logger) : ControllerBase
    {
        private readonly IAdminClassService _classService = classService;
        private readonly ILogger<AdminClassController> _logger = logger;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminClassDTO>>> GetAllClasses()
        {
            try
            {
                var classes = await _classService.GetAllClassesAsync();
                return Ok(classes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all classes");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdminClassDTO>> GetClassById(int id)
        {
            try
            {
                _logger.LogInformation("Attempting to fetch class with ID: {Id}", id);

                var classDto = await _classService.GetClassByIdAsync(id);

                if (classDto == null)
                {
                    _logger.LogWarning("Class with ID {Id} not found", id);
                    return NotFound(new { message = $"Class with ID {id} not found" });
                }

                _logger.LogInformation("Successfully retrieved class with ID: {Id}", id);
                return Ok(classDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching class with ID: {Id}", id);
                return StatusCode(500, new
                {
                    message = "Internal server error",
                    details = ex.Message,
                    stackTrace = ex.StackTrace // Remove in production
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult<AdminClassDTO>> CreateClass([FromBody] AdminClassDTO classDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _classService.AddClassAsync(classDto);
                return CreatedAtAction(nameof(GetClassById), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating class");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AdminClassDTO>> UpdateClass(int id, [FromBody] AdminClassDTO classDto)
        {
            try
            {
                if (id != classDto.Id)
                {
                    return BadRequest("ID mismatch");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _classService.UpdateClassAsync(classDto);
                if (result == null)
                {
                    return NotFound($"Class with ID {id} not found");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating class with ID: {Id}", id);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost("{id}/softdelete")]  // Changed to POST from DELETE
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                var result = await _classService.SoftDeleteClassAsync(id);
                if (!result)
                {
                    return NotFound($"Class with ID {id} not found");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while soft deleting class {Id}", id);
                return StatusCode(500, new { message = "Internal server error", details = ex.Message });
            }
        }
    }
}