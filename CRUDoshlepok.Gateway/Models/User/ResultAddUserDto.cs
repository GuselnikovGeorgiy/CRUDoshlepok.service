namespace CRUDoshlepok.Gateway.Models.User;

public sealed record ResultAddUserDto
{
    public required Guid Id { get; init; }
    public required bool Success { get; init; }
    public required string? Error { get; init; }
}