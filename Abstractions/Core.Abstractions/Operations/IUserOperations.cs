using Core.Abstractions.Models;

namespace Core.Abstractions.Operations;

public interface IUserOperations
{
    Task<Result<ResultAddUserOperationModel>> AddUserAsync(AddUserOperationModel user);
    
    Task<Result<ICollection<UserOperationModel>>> GetPaginatedUsersAsync(int pageIndex, int pageSize);
    
    Task<Result<ICollection<UserOperationModel>>> GetUserByIdAsync(Guid userId);
}