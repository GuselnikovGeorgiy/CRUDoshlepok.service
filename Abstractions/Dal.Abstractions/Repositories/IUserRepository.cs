using Dal.Abstractions.Models;

namespace Dal.Abstractions.Repositories;

public interface IUserRepository
{
    Task<Result<ICollection<UserRepositoryModel>>> GetPaginatedUsersAsync(int pageIndex, int pageSize);
    
    Task<Result<UserRepositoryModel>> GetUserByIdAsync(Guid userId);
    
    Task<Result<UserRepositoryModel>> AddUserAsync(UserRepositoryModel user);
}