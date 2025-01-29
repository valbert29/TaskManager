namespace TaskManager.Domain.Entities;

public sealed record TaskResponse(
    Guid Id,
    string Title,
    int Priority,
    string Status);