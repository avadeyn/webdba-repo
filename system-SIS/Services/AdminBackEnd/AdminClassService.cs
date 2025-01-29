using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto;
using system_SIS.Data;
using system_SIS.Models.AdminBackEnd;

namespace system_SIS.Services.AdminBackEnd
{
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
                .Select(c => new AdminClassDTO
                {
                    Id = c.Id,
                    Section = c.Section,
                    Faculty = c.Faculty,
                    Subject = c.Subject,
                    GradeLevel = c.GradeLevel
                })
                .ToListAsync();

            return classes;
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
            var classEntity = new AdminClass
            {
                Section = classDto.Section,
                Faculty = classDto.Faculty,
                Subject = classDto.Subject,
                GradeLevel = classDto.GradeLevel
            };

            _context.AdminClasses.Add(classEntity);
            await _context.SaveChangesAsync();

            classDto.Id = classEntity.Id;
            return classDto;
        }

        public async Task<AdminClassDTO?> UpdateClassAsync(AdminClassDTO classDto)
        {
            var classEntity = await _context.AdminClasses.FindAsync(classDto.Id);
            if (classEntity == null)
            {
                return null;
            }

            classEntity.Section = classDto.Section;
            classEntity.Faculty = classDto.Faculty;
            classEntity.Subject = classDto.Subject;
            classEntity.GradeLevel = classDto.GradeLevel;

            await _context.SaveChangesAsync();
            return classDto;
        }

        public async Task DeleteClassAsync(int id)
        {
            var classEntity = await _context.AdminClasses.FindAsync(id);
            if (classEntity != null)
            {
                _context.AdminClasses.Remove(classEntity);
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
            await _context.SaveChangesAsync();
            return true;
        }
    }
}