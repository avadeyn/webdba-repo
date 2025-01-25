using system_SIS.Models.AdminBackEnd;

namespace system_SIS.Services.AdminBackEnd
{
    public interface IAdminScheduleService
    {
        Task<IEnumerable<AdminSchedule>> GetSchedulesByClassIdAsync(int classId);
        Task<IEnumerable<AdminSchedule>> GetAllSchedulesAsync();
        Task<AdminSchedule> AddScheduleAsync(AdminSchedule schedule);
        Task<AdminSchedule?> UpdateScheduleAsync(AdminSchedule schedule);
        Task<bool> SoftDeleteScheduleAsync(int id);
    }
}   