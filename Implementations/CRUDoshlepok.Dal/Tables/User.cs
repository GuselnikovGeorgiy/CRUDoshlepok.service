namespace CRUDoshlepok.Dal.Tables;

public record User
{
    public Guid Id { get; init; }
    public required int Age { get; init; }
}