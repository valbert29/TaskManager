namespace TaskManager.Domain.Entities;

public abstract class AggregateRoot<TId>
{
    public TId Id { get; protected set; } = default!;
    
    protected AggregateRoot() { }
    
    protected AggregateRoot(TId id) => Id = id;
}