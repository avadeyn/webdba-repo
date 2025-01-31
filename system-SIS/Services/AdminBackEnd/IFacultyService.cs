using system_SIS.Models.AdminBackEnd;

namespace system_SIS.Services.AdminBackEnd
{
    public interface IFacultyService
    {
        Task<IEnumerable<Faculty>> GetAllFacultyAsync();
        Task<Faculty> GetFacultyByIdAsync(int id);
        Task<Faculty> AddFacultyAsync(Faculty faculty);
        Task<Faculty> UpdateFacultyAsync(Faculty faculty);
        Task SoftDeleteFacultyAsync(int id);
        Task<IEnumerable<Faculty>> GetDeletedFacultyAsync();
        Task RestoreFacultyAsync(int id);
    }
}