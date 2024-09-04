namespace ChallengeN5.Application.MapperProfiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Employee, EmployeeDto>().ReverseMap();
        CreateMap<Permission, PermissionDto>().ReverseMap();
        CreateMap<PermissionType, PermissionTypeDto>().ReverseMap();
    }
}
