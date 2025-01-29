using MediatR;
using TaskManager.Domain.Entities;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.Queries.Tasks;

public sealed record GetAllTasksQuery() 
    : IRequest<List<TaskResponse>>;