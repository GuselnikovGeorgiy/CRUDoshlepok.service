namespace CRUDoshlepok.Gateway.Models.User;

public sealed record AddUserDto
{
    public required int Age { get; init; }
}