using AutoMapper;
using Eccommerce.API.Entities;

namespace Eccommerce.API;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<SuperHeroEntity, SuperHero>().ReverseMap();
        CreateMap<EmployeeModel, Employee>().ReverseMap();
        CreateMap<Employee, ViewModel>().ReverseMap();
        CreateMap<Department, DepartmentsModel>().ReverseMap();
        CreateMap<EmployeeViewModel, EmployeeModel>().ReverseMap();
    }
}