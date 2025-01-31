using AutoMapper;
using system_SIS.Models.AdminBackEnd;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AdminClass, AdminClassDTO>().ReverseMap();
    }
}