using AutoMapper;
using Microsoft.EntityFrameworkCore;  
using system_SIS.Models.AdminBackEnd;
using system_SIS.Services.AdminBackEnd;
using system_SIS.Services;

public class AdminClassService : IAdminClassService
{
    private readonly ApplicationDBContext _context;
    private readonly IMapper _mapper;

    public AdminClassService(ApplicationDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AdminClassDTO>> GetAllClassesAsync()
    {
        var classes = await _context.AdminClasses
            .Where(c => !c.IsDeleted)
            .ToListAsync();

        return _mapper.Map<IEnumerable<AdminClassDTO>>(classes);
    }

    public async Task<AdminClassDTO> GetClassByIdAsync(int id)
    {
        var adminClass = await _context.AdminClasses
            .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

        if (adminClass == null)
            return null;

        return _mapper.Map<AdminClassDTO>(adminClass);
    }

    public async Task<AdminClassDTO> AddClassAsync(AdminClassDTO classDto)
    {
        var adminClass = _mapper.Map<AdminClass>(classDto);
        adminClass.SchoolYear = string.IsNullOrEmpty(classDto.SchoolYear)
            ? $"{DateTime.Now.Year}-{DateTime.Now.Year + 1}"
            : classDto.SchoolYear;
        adminClass.IsDeleted = false;

        _context.AdminClasses.Add(adminClass);
        await _context.SaveChangesAsync();

        return _mapper.Map<AdminClassDTO>(adminClass);
    }

    public async Task<AdminClassDTO?> UpdateClassAsync(AdminClassDTO classDto)
    {
        var existingClass = await _context.AdminClasses
            .FirstOrDefaultAsync(c => c.Id == classDto.Id);

        if (existingClass == null)
        {
            return null;
        }

        _mapper.Map(classDto, existingClass);
        await _context.SaveChangesAsync();

        return _mapper.Map<AdminClassDTO>(existingClass);
    }

    public async Task DeleteClassAsync(int id)
    {
        var adminClass = await _context.AdminClasses.FindAsync(id);
        if (adminClass != null)
        {
            _context.AdminClasses.Remove(adminClass);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> SoftDeleteClassAsync(int id)
    {
        var adminClass = await _context.AdminClasses
            .FirstOrDefaultAsync(c => c.Id == id);

        if (adminClass == null)
            return false;

        adminClass.IsDeleted = true;

        // Also mark related schedules as deleted
        var relatedSchedules = await _context.AdminSchedules
            .Where(s => s.ClassId == id)
            .ToListAsync();

        foreach (var schedule in relatedSchedules)
        {
            schedule.IsDeleted = true;
        }

        await _context.SaveChangesAsync();
        return true;
    }
}