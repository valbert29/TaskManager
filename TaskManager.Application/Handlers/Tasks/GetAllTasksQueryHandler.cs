using AutoMapper;
using MediatR;
using TaskManager.Application.Queries.Tasks;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Handlers.Tasks;

public class GetAllTasksQueryHandler(
    ITaskRepository taskRepository,
    IMapper mapper)
    : IRequestHandler<GetAllTasksQuery, List<TaskResponse>>
{
    public async Task<List<TaskResponse>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        var tasks = await taskRepository.GetAllAsync();
        return mapper.Map<List<TaskResponse>>(tasks);
    }
}