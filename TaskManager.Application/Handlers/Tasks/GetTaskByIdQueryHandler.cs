using AutoMapper;
using MediatR;
using TaskManager.Application.Queries.Tasks;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Handlers.Tasks;

internal sealed class GetTaskByIdQueryHandler(
    ITaskRepository taskRepository,
    IMapper mapper)
    : IRequestHandler<GetTaskByIdQuery, TaskResponse>
{
    public async Task<TaskResponse> Handle(
        GetTaskByIdQuery request, 
        CancellationToken cancellationToken)
    {
        var task = await taskRepository.GetByIdAsync(request.TaskId)
                   ?? throw new Domain.Exceptions.DomainException("Task not found");
        
        return mapper.Map<TaskResponse>(task);
    }
}