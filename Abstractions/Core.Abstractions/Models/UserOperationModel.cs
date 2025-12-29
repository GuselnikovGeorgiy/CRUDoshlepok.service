namespace Core.Abstractions.Models;

public sealed record UserOperationModel
{
    public required Guid Id { get; init; }
    public required int Age { get; init; }
}