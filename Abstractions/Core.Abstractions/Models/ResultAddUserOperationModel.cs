namespace Core.Abstractions.Models;

public class ResultAddUserOperationModel
{
    public required int Id { get; init; }
    public required bool Success { get; init; }
    public required string? Error { get; init; }
}