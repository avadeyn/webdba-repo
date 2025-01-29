using Microsoft.EntityFrameworkCore;
using system_SIS.Models.AdminBackEnd;

namespace system_SIS.Services.AdminBackEnd
{
    public class AdminScheduleService : IAdminScheduleService
    {
        private readonly ApplicationDBContext _context;

        public AdminScheduleService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AdminSchedule>> GetAllSchedulesAsync()
        {
            return await _context.AdminSchedules
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<AdminSchedule>> GetSchedulesByClassIdAsync(int classId)
        {
            return await _context.AdminSchedules
                .Where(s => !s.IsDeleted && s.ClassId == classId)
                .ToListAsync();
        }

        public async Task<AdminSchedule> AddScheduleAsync(AdminSchedule schedule)
        {
            // Verify the ClassId is set correctly
            if (schedule.ClassId <= 0)
            {
                throw new ArgumentException("Invalid ClassId provided");
            }

            // Verify the class exists
            var classExists = await _context.AdminClasses.AnyAsync(c => c.Id == schedule.ClassId);
            if (!classExists)
            {
                throw new ArgumentException($"Class with ID {schedule.ClassId} does not exist");
            }

            _context.AdminSchedules.Add(schedule);
            await _context.SaveChangesAsync();
            return schedule;
        }

        public async Task<AdminSchedule?> UpdateScheduleAsync(AdminSchedule schedule)
        {
            var existingSchedule = await _context.AdminSchedules.FindAsync(schedule.Id);
            if (existingSchedule == null || existingSchedule.IsDeleted)
            {
                return null;
            }

            existingSchedule.Day = schedule.Day;
            existingSchedule.Session = schedule.Session;
            existingSchedule.Subject = schedule.Subject;
            existingSchedule.Start = schedule.Start;
            existingSchedule.End = schedule.End;
            existingSchedule.ClassId = schedule.ClassId;

            await _context.SaveChangesAsync();
            return existingSchedule;
        }

        public async Task<bool> SoftDeleteScheduleAsync(int id)
        {
            var schedule = await _context.AdminSchedules.FindAsync(id);
            if (schedule == null)
            {
                return false;
            }

            schedule.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}