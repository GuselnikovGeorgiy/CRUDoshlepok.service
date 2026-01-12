namespace CRUDoshlepok.Gateway.Models.User;

public sealed record ResultAddUserDto
{
    public required Guid Id { get; init; }
    public required int Age { get; init; }
}