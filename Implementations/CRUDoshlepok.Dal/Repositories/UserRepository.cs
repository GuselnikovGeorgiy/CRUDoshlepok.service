using AutoMapper;
using CRUDoshlepok.Dal.Context;
using CRUDoshlepok.Dal.Tables;
using Dal.Abstractions;
using Dal.Abstractions.Models;
using Dal.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CRUDoshlepok.Dal.Repositories;

internal sealed class UserRepository(
    IModelReader modelReader,
    IModelUpdater modelUpdater,
    IMapper mapper) 
    : IUserRepository
{
    public async Task<Result<ICollection<UserRepositoryModel>>> GetPaginatedUsersAsync(int pageIndex, int pageSize)
    {
        var result = await modelReader.Users
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return Result<ICollection<UserRepositoryModel>>.Success(mapper.Map<ICollection<UserRepositoryModel>>(result));
    }

    public async Task<Result<UserRepositoryModel>> GetUserByIdAsync(Guid userId)
    {
        var result = await modelReader.Users
            .FirstOrDefaultAsync(x => x.Id == userId);
        
        return Result<UserRepositoryModel>.Success(mapper.Map<UserRepositoryModel>(result));
    }

    public async Task<Result<UserRepositoryModel>> AddUserAsync(AddUserRepositoryModel user)
    {
        var result = mapper.Map<User>(user);
        await modelUpdater.Users.AddAsync(result);
        await  modelUpdater.SaveChangesAsync();
        
        return Result<UserRepositoryModel>.Success(mapper.Map<UserRepositoryModel>(result));
    }
}