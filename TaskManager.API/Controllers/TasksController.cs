using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Commands.Tasks;
using TaskManager.Application.Queries.Tasks;
using TaskManager.Domain.Exceptions;

namespace TaskManager.API.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTasks()
    {
        var query = new GetAllTasksQuery();
        var tasks = await _mediator.Send(query);
        return Ok(tasks);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask(CreateTaskCommand request)
    {
        var command = new CreateTaskCommand(request.Title, request.Priority);
        var taskId = await _mediator.Send(command);
        return Ok(taskId);
    }

    [HttpPut("{taskId}/complete")]
    public async Task<IActionResult> CompleteTask(Guid taskId)
    {
        try
        {
            await _mediator.Send(new CompleteTaskCommand(taskId));
            return NoContent();
        }
        catch (DomainException ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
}