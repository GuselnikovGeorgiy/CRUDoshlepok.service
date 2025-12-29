using CRUDoshlepok.Dal.Tables;
using Microsoft.EntityFrameworkCore;

namespace CRUDoshlepok.Dal.Context;

internal interface IModelUpdater : IDisposable
{
    DbSet<User> Users { get; }
    
    Task<int> SaveChangesAsync();
}