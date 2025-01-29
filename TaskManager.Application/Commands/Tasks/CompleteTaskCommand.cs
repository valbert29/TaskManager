using MediatR;

namespace TaskManager.Application.Commands.Tasks;

public sealed record CompleteTaskCommand(Guid TaskId) : IRequest;