using AutoMapper;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Mappings;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<Domain.Entities.Task, TaskResponse>()
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => src.Status.ToString()))
            .ForCtorParam("Priority", opt =>
                opt.MapFrom(src => src.Priority.Value));
    }
}