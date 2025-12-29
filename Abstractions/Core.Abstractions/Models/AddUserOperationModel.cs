namespace Core.Abstractions.Models;

public sealed record AddUserOperationModel
{
    public required int Age { get; init; }
}