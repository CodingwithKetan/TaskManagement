using AutoMapper;
using Domain.Models;
using Shared.DataTransferObjects;

namespace TaskManagementSystem
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserTask, TaskBaseDto>().ReverseMap();
            CreateMap<TaskCreateRequest, UserTask>();
            CreateMap<TaskStatusUpdateDto, UserTask>().ForMember(t => t.Status, opt => opt.MapFrom(src => src.Status));
            CreateMap<Document, DocumentDto>().ReverseMap();
            CreateMap<EmployeeRegistrationDto, Employee>().ReverseMap();
        }
    }
}
