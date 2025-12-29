using Dal.Abstractions.Models;

namespace Dal.Abstractions.Repositories;

public interface IUserRepository
{
    Task<ICollection<UserRepositoryModel>> GetPaginatedUsersAsync(int pageIndex, int pageSize);
    
    Task<UserRepositoryModel> GetUserByIdAsync(Guid userId);
    
    Task<UserRepositoryModel> AddUserAsync(UserRepositoryModel user);
}