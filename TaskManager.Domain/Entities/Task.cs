using TaskManager.Domain.Exceptions;
using TaskManager.Domain.ValueObjects;

namespace TaskManager.Domain.Entities;

public class Task : AggregateRoot<Guid>
{
    public string Title { get; private set; }
    public Enums.TaskStatus Status { get; private set; }
    public Priority Priority { get; private set; }

    private Task() { } // Для EF Core

    public Task(string title, Priority priority)
    {
        Id = Guid.NewGuid();
        SetTitle(title);
        Priority = priority;
        Status = Enums.TaskStatus.New;
    }

    private void SetTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new DomainException("Task title cannot be empty");
        
        Title = title.Trim();
    }

    public void CompleteTask()
    {
        if (Status == Enums.TaskStatus.Completed)
            throw new DomainException("Task is already completed");
        
        Status = Enums.TaskStatus.Completed;
    }
}