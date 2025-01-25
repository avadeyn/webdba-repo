using Microsoft.AspNetCore.Mvc;
using system_SIS.Models.AdminBackEnd;
using system_SIS.Services.AdminBackEnd;

namespace system_SIS.Controllers.AdminBackEnd
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminScheduleController(IAdminScheduleService scheduleService, ILogger<AdminScheduleController> logger) : ControllerBase
    {
        private readonly IAdminScheduleService _scheduleService = scheduleService;
        private readonly ILogger<AdminScheduleController> _logger = logger;

        private const string FetchSchedulesLogMessage = "Successfully retrieved {Count} schedules";
        private const string CreateScheduleLogMessage = "Successfully created schedule with ID {ScheduleId}";

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminSchedule>>> GetAllSchedules()
        {
            try
            {
                _logger.LogInformation("Attempting to fetch all schedules");
                var schedules = await _scheduleService.GetAllSchedulesAsync();
                _logger.LogInformation(FetchSchedulesLogMessage, schedules.Count());
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching schedules");
                return StatusCode(500, new { message = "Internal server error", details = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<AdminSchedule>> CreateSchedule([FromBody] AdminSchedule schedule)
        {
            try
            {
                _logger.LogInformation("Attempting to create new schedule");
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Invalid model state for schedule creation");
                    return BadRequest(ModelState);
                }

                var result = await _scheduleService.AddScheduleAsync(schedule);
                _logger.LogInformation(CreateScheduleLogMessage, result.Id);
                return CreatedAtAction(nameof(GetAllSchedules), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating schedule");
                return StatusCode(500, new { message = "Internal server error", details = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<AdminSchedule>> UpdateSchedule(int id, [FromBody] AdminSchedule schedule)
        {
            try
            {
                if (id != schedule.Id)
                {
                    return BadRequest("ID mismatch");
                }

                _logger.LogInformation("Attempting to update schedule {Id}", id);
                var result = await _scheduleService.UpdateScheduleAsync(schedule);
                if (result == null)
                {
                    return NotFound($"Schedule with ID {id} not found");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating schedule {Id}", id);
                return StatusCode(500, new { message = "Internal server error", details = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            try
            {
                _logger.LogInformation("Attempting to soft delete schedule {Id}", id);
                var result = await _scheduleService.SoftDeleteScheduleAsync(id);
                if (!result)
                {
                    return NotFound($"Schedule with ID {id} not found");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting schedule {Id}", id);
                return StatusCode(500, new { message = "Internal server error", details = ex.Message });
            }
        }

        [HttpGet("class/{classId}")]
        public async Task<ActionResult<IEnumerable<AdminSchedule>>> GetSchedulesByClassId(int classId)
        {
            try
            {
                _logger.LogInformation("Attempting to fetch schedules for class {ClassId}", classId);

                // Add null check for service
                if (_scheduleService == null)
                {
                    _logger.LogError("Schedule service is null");
                    return StatusCode(500, "Schedule service not initialized");
                }

                var schedules = await _scheduleService.GetSchedulesByClassIdAsync(classId);

                // Add null check for schedules
                if (schedules == null)
                {
                    _logger.LogWarning("No schedules found for class {ClassId}", classId);
                    return Ok(new List<AdminSchedule>()); // Return empty list instead of null
                }

                _logger.LogInformation("Successfully retrieved {Count} schedules for class {ClassId}",
                    schedules.Count(), classId);

                return Ok(schedules);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching schedules for class {ClassId}", classId);
                // Return more detailed error message in development
                return StatusCode(500, new
                {
                    message = "Internal server error",
                    details = ex.Message,
                    stackTrace = ex.StackTrace // Remove this in production
                });
            }
        }
    }
}