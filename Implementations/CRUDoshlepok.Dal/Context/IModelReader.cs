using CRUDoshlepok.Dal.Tables;

namespace CRUDoshlepok.Dal.Context;

internal interface IModelReader
{
    IQueryable<User> Users { get; }
}