using MediatR;
using TaskStatus = TaskManager.Domain.Enums.TaskStatus;

namespace TaskManager.Application.Commands.Tasks;

public sealed record CreateTaskCommand(
    string Title,
    int Priority
) : IRequest<Guid>;