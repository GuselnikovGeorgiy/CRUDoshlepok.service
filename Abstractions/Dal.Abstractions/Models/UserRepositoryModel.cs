namespace Dal.Abstractions.Models;

public sealed record UserRepositoryModel
{
    public required Guid Id { get; init; }
    public required int Age { get; init; }
}