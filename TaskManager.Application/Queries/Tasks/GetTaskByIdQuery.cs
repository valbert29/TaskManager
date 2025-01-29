using MediatR;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Queries.Tasks;

public sealed record GetTaskByIdQuery(Guid TaskId) 
    : IRequest<TaskResponse>;