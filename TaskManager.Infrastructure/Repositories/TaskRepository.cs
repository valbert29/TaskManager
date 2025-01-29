using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Interfaces;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly ApplicationDbContext _context;

    public TaskRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<List<Domain.Entities.Task>> GetAllAsync() => 
        _context.Tasks.ToListAsync();

    public async Task AddAsync(Domain.Entities.Task task)
    {
        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
    }

    public async Task<Domain.Entities.Task?> GetByIdAsync(Guid id) => 
        await _context.Tasks.FindAsync(id);

    public async Task UpdateAsync(Domain.Entities.Task task)
    {
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
    }
}