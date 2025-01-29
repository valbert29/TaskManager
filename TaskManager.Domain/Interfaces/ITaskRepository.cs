namespace TaskManager.Domain.Interfaces;

public interface ITaskRepository
{
    Task<Entities.Task?> GetByIdAsync(Guid id);
    Task<List<Entities.Task>> GetAllAsync();
    Task AddAsync(Entities.Task task);
    Task UpdateAsync(Entities.Task task);
}