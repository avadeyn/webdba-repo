using AutoMapper;
using system_SIS.Models.AdminBackEnd;

namespace system_SIS.Mappings
{
    public class AdminClassMappingProfile : Profile
    {
        public AdminClassMappingProfile()
        {
            CreateMap<AdminClass, AdminClassDTO>();
            CreateMap<AdminClassDTO, AdminClass>();
        }
    }
}