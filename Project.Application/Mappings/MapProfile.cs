using AutoMapper;
using Project.Application.Dto;
using Project.Domain.Model;

namespace Project.Application.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Employee, EmployeeGet>().ReverseMap();
            CreateMap<EmployeePost, Employee>().ReverseMap();
            CreateMap<EmployeePut, Employee>();
            CreateMap<TokenPostRequest, User>();
        }
    }
}