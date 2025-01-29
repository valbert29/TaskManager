using System.ComponentModel;
using MediatR;
using TaskManager.Application.Commands.Tasks;
using TaskManager.Domain.Exceptions;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Handlers.Tasks;

internal sealed class CompleteTaskCommandHandler(
    ITaskRepository taskRepository)
    : IRequestHandler<CompleteTaskCommand>
{
    public async Task Handle(
        CompleteTaskCommand request,
        CancellationToken cancellationToken)
    {
        var task = await taskRepository.GetByIdAsync(request.TaskId) ?? throw new DomainException("Task not found");

        task.CompleteTask();

        await taskRepository.UpdateAsync(task);
    }
}