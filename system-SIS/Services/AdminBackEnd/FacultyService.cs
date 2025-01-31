using Microsoft.EntityFrameworkCore;
using system_SIS.Models.AdminBackEnd;

namespace system_SIS.Services.AdminBackEnd
{
    public class FacultyService : IFacultyService
    {
        private readonly ApplicationDBContext _context;

        public FacultyService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Faculty> AddFacultyAsync(Faculty faculty)
        {
            try
            {
                faculty.IsDeleted = false;
                _context.Faculties.Add(faculty);
                await _context.SaveChangesAsync();
                return faculty;
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
                return await _context.Faculties
                    .Where(f => !f.IsDeleted)
                    .ToListAsync();
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
                // Using pattern matching with 'is' operator
                var faculty = await _context.Faculties
                    .FirstOrDefaultAsync(f => f.Id == id && !f.IsDeleted);

                // Using simplified null check
                if (faculty is null)
                {
                    throw new KeyNotFoundException($"Faculty with ID {id} not found");
                }
                return faculty;
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
                // Using pattern matching with 'is' operator
                var existingFaculty = await _context.Faculties
                    .FirstOrDefaultAsync(f => f.Id == faculty.Id && !f.IsDeleted);

                // Using simplified null check
                if (existingFaculty is null)
                {
                    throw new KeyNotFoundException($"Faculty with ID {faculty.Id} not found");
                }

                faculty.IsDeleted = existingFaculty.IsDeleted;
                _context.Entry(existingFaculty).CurrentValues.SetValues(faculty);
                await _context.SaveChangesAsync();
                return existingFaculty;
            }
            catch (Exception ex) when (ex is not KeyNotFoundException)
            {
                throw new Exception($"Error updating faculty member with ID {faculty.Id}", ex);
            }
        }

        public async Task SoftDeleteFacultyAsync(int id)
        {
            try
            {
                // Using pattern matching with 'is' operator
                var faculty = await _context.Faculties.FindAsync(id);

                // Using simplified null check
                if (faculty is null)
                {
                    throw new KeyNotFoundException($"Faculty with ID {id} not found");
                }

                faculty.IsDeleted = true;
                faculty.Status = "Inactive";

                await _context.SaveChangesAsync();
            }
            catch (Exception ex) when (ex is not KeyNotFoundException)
            {
                throw new Exception($"Error deleting faculty member with ID {id}", ex);
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