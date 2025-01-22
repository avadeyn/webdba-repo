using Microsoft.EntityFrameworkCore;
using system_SIS.Models.NewFolder;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace system_SIS.Services.NewFolder
{
    public interface IFacultyService
    {
        Task<Faculty> AddFacultyAsync(Faculty faculty);
        Task<IEnumerable<Faculty>> GetAllFacultyAsync();
        Task<Faculty> GetFacultyByIdAsync(int id);
        Task<Faculty> UpdateFacultyAsync(Faculty faculty);
        Task SoftDeleteFacultyAsync(int id);
        // Optional: Add these methods if you want to manage deleted records
        Task<IEnumerable<Faculty>> GetDeletedFacultyAsync();
        Task RestoreFacultyAsync(int id);
    }

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
                faculty.IsDeleted = false; // Ensure new faculty members are not marked as deleted
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
                // Only return non-deleted faculty members
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
                var faculty = await _context.Faculties
                    .FirstOrDefaultAsync(f => f.Id == id && !f.IsDeleted);

                if (faculty == null)
                {
                    throw new KeyNotFoundException($"Faculty with ID {id} not found");
                }
                return faculty;
            }
            catch (Exception ex) when (!(ex is KeyNotFoundException))
            {
                throw new Exception($"Error retrieving faculty member with ID {id}", ex);
            }
        }

        public async Task<Faculty> UpdateFacultyAsync(Faculty faculty)
        {
            try
            {
                var existingFaculty = await _context.Faculties
                    .FirstOrDefaultAsync(f => f.Id == faculty.Id && !f.IsDeleted);

                if (existingFaculty == null)
                {
                    throw new KeyNotFoundException($"Faculty with ID {faculty.Id} not found");
                }

                // Preserve the IsDeleted status
                faculty.IsDeleted = existingFaculty.IsDeleted;

                _context.Entry(existingFaculty).CurrentValues.SetValues(faculty);
                await _context.SaveChangesAsync();
                return existingFaculty;
            }
            catch (Exception ex) when (!(ex is KeyNotFoundException))
            {
                throw new Exception($"Error updating faculty member with ID {faculty.Id}", ex);
            }
        }

        public async Task SoftDeleteFacultyAsync(int id)
        {
            try
            {
                var faculty = await _context.Faculties.FindAsync(id);
                if (faculty == null)
                {
                    throw new KeyNotFoundException($"Faculty with ID {id} not found");
                }

                // Instead of removing the record, mark it as deleted
                faculty.IsDeleted = true;
                faculty.Status = "Inactive"; // Update status to reflect deletion

                await _context.SaveChangesAsync();
            }
            catch (Exception ex) when (!(ex is KeyNotFoundException))
            {
                throw new Exception($"Error deleting faculty member with ID {id}", ex);
            }
        }

        // Optional: Methods for managing deleted records
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
                var faculty = await _context.Faculties
                    .FirstOrDefaultAsync(f => f.Id == id && f.IsDeleted);

                if (faculty == null)
                {
                    throw new KeyNotFoundException($"Deleted faculty with ID {id} not found");
                }

                faculty.IsDeleted = false;
                faculty.Status = "Active"; // Restore status to active

                await _context.SaveChangesAsync();
            }
            catch (Exception ex) when (!(ex is KeyNotFoundException))
            {
                throw new Exception($"Error restoring faculty member with ID {id}", ex);
            }
        }
    }
}