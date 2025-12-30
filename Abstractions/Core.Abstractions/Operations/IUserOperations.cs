using Core.Abstractions.Models;

namespace Core.Abstractions.Operations;

public interface IUserOperations
{
    Task<Result<UserOperationModel>> AddUserAsync(AddUserOperationModel user);
    
    Task<Result<ICollection<UserOperationModel>>> GetPaginatedUsersAsync(int pageIndex, int pageSize);
    
    Task<Result<UserOperationModel>> GetUserByIdAsync(Guid userId);
}