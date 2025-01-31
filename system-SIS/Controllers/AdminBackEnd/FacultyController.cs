using Microsoft.AspNetCore.Mvc;
using system_SIS.Models.NewFolder;
using system_SIS.Services.NewFolder;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using system_SIS.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Runtime.InteropServices;

namespace system_SIS.Controllers.NewFolder
{
    [ApiController]
    [Route("api/[controller]")]
	public class FacultyController : ControllerBase
	{
		private readonly IFacultyService _facultyService;
		private readonly ApplicationDBContext _context;

		// Constructor for DI: inject both IFacultyService and ApplicationDBContext
		public FacultyController(IFacultyService facultyService, ApplicationDBContext context)
		{
			_facultyService = facultyService; // Assign the injected IFacultyService
			_context = context;               // Assign the injected ApplicationDBContext
		}


		// this code is for the view or list of all faculty - DONE
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Faculty>>> GetAllFaculty()
		{
			try
			{
				// Call the service to retrieve faculty members via the stored procedure
				var faculties = await _facultyService.GetAllFacultyAsync();
				return Ok(faculties); // Return the list of faculties as a response
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		// this code is to select favulty by ID - DONE
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


		// this code is used to add faculty - DONE
		[HttpPost]
		public async Task<ActionResult<Faculty>> AddFaculty([FromBody] Faculty faculty)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}

				// Call the service to execute the stored procedure
				await _facultyService.AddFacultyAsync(faculty);

				return Ok(faculty);

			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}


		// this code is update info - DONE
		[HttpPut("{id}")]
		public async Task<ActionResult<Faculty>> UpdateFaculty(int id, [FromBody] Faculty faculty)
		{
			try
			{
				if (id != faculty.Id)
				{
					return BadRequest("ID mismatch.");
				}

				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}

				var updatedFaculty = await _facultyService.UpdateFacultyAsync(faculty);

				if (updatedFaculty is null)
				{
					return NotFound($"Faculty with ID {id} not found.");
				}

				return Ok(updatedFaculty);
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
				// Call the service method to perform the soft delete operation
				await _facultyService.SoftDeleteFacultyAsync(id);

				// Return 204 No Content response indicating the operation was successful
				return NoContent();
			}
			catch (KeyNotFoundException ex)
			{
				// If the faculty is not found or already deleted, return 404 Not Found
				return NotFound(ex.Message);
			}
			catch (Exception ex)
			{
				// Catch all other exceptions and return a 500 Internal Server Error
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