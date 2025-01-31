using Microsoft.EntityFrameworkCore;
using system_SIS.Models.NewFolder;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace system_SIS.Services.NewFolder
{
    public interface IFacultyService
    {
        Task<Faculty> AddFacultyAsync(Faculty faculty);
        Task<IEnumerable<Faculty>> GetAllFacultyAsync();
        Task<Faculty> GetFacultyByIdAsync(int id);
        Task<Faculty> UpdateFacultyAsync(Faculty faculty);
        Task SoftDeleteFacultyAsync(int id);
        Task<IEnumerable<Faculty>> GetDeletedFacultyAsync();
        Task RestoreFacultyAsync(int id);
    }

    // Using primary constructor syntax
    public class FacultyService(ApplicationDBContext context) : IFacultyService
    {
        private readonly ApplicationDBContext _context = context;

		public async Task<Faculty> AddFacultyAsync(Faculty faculty)
		{
			try
			{
				var addFaculty = new[]
				{
					new SqlParameter("@FacultyName", faculty.FacultyName),
					new SqlParameter("@Email", faculty.Email),
					new SqlParameter("@ContactNumber", faculty.ContactNumber),
					new SqlParameter("@Status", faculty.Status),
					new SqlParameter("@DateOfBirth", faculty.DateOfBirth),
					new SqlParameter("@Gender", faculty.Gender),
					new SqlParameter("@Address", faculty.Address),
					new SqlParameter("@DateOfHire", faculty.DateOfHire),
					new SqlParameter("@Position", faculty.Position),
					new SqlParameter("@IsDeleted", faculty.IsDeleted)
				};

				await _context.Database.ExecuteSqlRawAsync("Exec insertFaculty @FacultyName, @Email, @ContactNumber, @Status, @DateOfBirth, @Gender, @Address, @DateOfHire, @Position, @IsDeleted", addFaculty);
				return faculty; // Return the added faculty
			}
			catch (Exception ex)
			{
				throw new Exception("Error adding faculty member", ex);
			}
		}

        public async Task<IEnumerable<Faculty>> GetAllFacultyAsync()
        {
			try
			{
				// Define the stored procedure call with ExecuteSqlRawAsync
				var faculties = await _context.Faculties
					.FromSqlRaw("Exec viewFacultyList")
					.ToListAsync();

				return faculties;
			}
			catch (Exception ex)
            {
                throw new Exception("Error retrieving faculty members", ex);
            }
        }

        public async Task<Faculty> GetFacultyByIdAsync(int id)
        {
            try
			{
				var facultyIdParam = new SqlParameter("@Id", id);
				var facultyList = await _context.Faculties.FromSqlRaw("Exec selectFaculty @Id", facultyIdParam).ToListAsync();

				if (facultyIdParam is null)
				{
					throw new KeyNotFoundException($"Faculty with ID {id} not found.");
				}

                return facultyList.FirstOrDefault(x => x.Id == id);
			}
            catch (Exception ex) when (ex is not KeyNotFoundException)
            {
                throw new Exception($"Error retrieving faculty member with ID {id}", ex);
            }
        }

		public async Task<Faculty> UpdateFacultyAsync(Faculty faculty)
		{
			try
			{
				var parameters = new[]
				{
			        new SqlParameter("@FacultyId", faculty.Id),
			        new SqlParameter("@Email", faculty.Email),
			        new SqlParameter("@ContactNumber", faculty.ContactNumber),
			        new SqlParameter("@Status", faculty.Status),
			        new SqlParameter("@Address", faculty.Address),
			        new SqlParameter("@Position", faculty.Position)
		        };

				// Execute the stored procedure
				await _context.Database.ExecuteSqlRawAsync(
					"EXEC updateFaculty @Email, @ContactNumber, @Status, @Address, @Position, @FacultyId",
					parameters);

				return faculty; // Return the updated faculty object
			}
			catch (SqlException ex)
			{
				if (ex.Message.Contains("Faculty with the provided ID does not exist"))
				{
					throw new KeyNotFoundException($"Faculty with ID {faculty.Id} not found.");
				}

				throw new Exception($"Error updating faculty member with ID {faculty.Id}", ex);
			}
		}


		public async Task SoftDeleteFacultyAsync(int id)
		{
			try
			{
				var facultyId = new SqlParameter("@Id", id);

				// Execute the stored procedure to soft delete the faculty
				await _context.Database.ExecuteSqlRawAsync("Exec removeFaculty @Id", facultyId);
			}
			catch (SqlException ex)
			{
				// Handle the specific SQL error raised by RAISERROR in the stored procedure
				if (ex.Message.Contains("Faculty with the provided ID does not exist"))
				{
					throw new KeyNotFoundException($"Faculty with ID {id} not found or already deleted.");
				}
				else
				{
					// For any other exceptions, rethrow them
					throw new Exception($"Error deleting faculty member with ID {id}", ex);
				}
			}
		}

		public async Task<IEnumerable<Faculty>> GetDeletedFacultyAsync()
        {
            try
            {
                return await _context.Faculties
                    .Where(f => f.IsDeleted)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving deleted faculty members", ex);
            }
        }

        public async Task RestoreFacultyAsync(int id)
        {
            try
            {
                // Using pattern matching with 'is' operator
                var faculty = await _context.Faculties
                    .FirstOrDefaultAsync(f => f.Id == id && f.IsDeleted);

                // Using simplified null check
                if (faculty is null)
                {
                    throw new KeyNotFoundException($"Deleted faculty with ID {id} not found");
                }

                faculty.IsDeleted = false;
                faculty.Status = "Active";

                await _context.SaveChangesAsync();
            }
            catch (Exception ex) when (ex is not KeyNotFoundException)
            {
                throw new Exception($"Error restoring faculty member with ID {id}", ex);
            }
        }
    }
}