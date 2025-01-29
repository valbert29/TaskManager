using MediatR;
using TaskManager.Application.Commands.Tasks;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Handlers.Tasks;

internal sealed class CreateTaskCommandHandler(
    ITaskRepository taskRepository) 
    : IRequestHandler<CreateTaskCommand, Guid>
{
    public async Task<Guid> Handle(
        CreateTaskCommand request, 
        CancellationToken cancellationToken)
    {
        var task = new Domain.Entities.Task(
            request.Title, 
            new Domain.ValueObjects.Priority(request.Priority));

        await taskRepository.AddAsync(task);
        return task.Id;
    }
}