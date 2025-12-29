using Dal.Abstractions.Models;
using Dal.Abstractions.Repositories;

namespace CRUDoshlepok.Dal.Repositories;

public class UserRepository : IUserRepository
{
    public Task<ICollection<UserRepositoryModel>> GetPaginatedUsersAsync(int pageIndex, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<UserRepositoryModel> GetUserByIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<UserRepositoryModel> AddUserAsync(UserRepositoryModel user)
    {
        throw new NotImplementedException();
    }
}