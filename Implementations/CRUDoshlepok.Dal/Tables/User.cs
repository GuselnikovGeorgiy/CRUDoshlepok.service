namespace CRUDoshlepok.Dal.Tables;

public record User
{
    public required Guid Id { get; init; }
    public required int Age { get; init; }
}