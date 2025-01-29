using TaskManager.Domain.Exceptions;

namespace TaskManager.Domain.ValueObjects;

public class Priority : ValueObject
{
    public int Value { get; }

    public Priority(int value)
    {
        if (value is < 1 or > 5)
            throw new DomainException("Priority must be between 1 and 5");
        
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}