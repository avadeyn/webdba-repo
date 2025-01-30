using system_SIS.Models.AdminBackEnd;

namespace system_SIS.Services.AdminBackEnd
{
    public interface IAdminClassService
    {
        Task<IEnumerable<AdminClassDTO>> GetAllClassesAsync();
        Task<AdminClassDTO> GetClassByIdAsync(int id);
        Task<AdminClassDTO> AddClassAsync(AdminClassDTO classDto);
        Task<AdminClassDTO?> UpdateClassAsync(AdminClassDTO classDto);
        Task DeleteClassAsync(int id);
        Task<bool> SoftDeleteClassAsync(int id);
    }
}
    