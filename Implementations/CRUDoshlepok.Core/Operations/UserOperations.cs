using AutoMapper;
using Core.Abstractions;
using Core.Abstractions.Models;
using Core.Abstractions.Operations;
using Dal.Abstractions.Models;
using Dal.Abstractions.Repositories;

namespace CRUDoshlepok.Core.Operations;

public class UserOperations(
    IMapper mapper,
    IUserRepository userRepository) 
    
    : IUserOperations
{
    public async Task<Result<UserOperationModel>> AddUserAsync(AddUserOperationModel user)
    {
        var result = await userRepository.AddUserAsync(mapper.Map<AddUserRepositoryModel>(user));

        return result.IsSuccess
            ? Result<UserOperationModel>.Success(
                mapper.Map<UserOperationModel>(result.Value))
            : new Result<UserOperationModel>(null!, result.IsSuccess, Error.Failure(result.Error.Message));

    }

    public async Task<Result<ICollection<UserOperationModel>>> GetPaginatedUsersAsync(int pageIndex, int pageSize)
    {
        var result = await userRepository.GetPaginatedUsersAsync(pageIndex, pageSize);
        
        return result.IsSuccess 
            ? Result<ICollection<UserOperationModel>>.Success(
                mapper.Map<ICollection<UserOperationModel>>(result.Value))
            : new Result<ICollection<UserOperationModel>>([], result.IsSuccess, Error.Failure(result.Error.Message));
    }

    public async Task<Result<UserOperationModel>> GetUserByIdAsync(Guid userId)
    {
        var result = await userRepository.GetUserByIdAsync(userId);

        return result.IsSuccess
            ? Result<UserOperationModel>.Success(
                mapper.Map<UserOperationModel>(result.Value))
            : new Result<UserOperationModel>(null!, result.IsSuccess, Error.Failure(result.Error.Message));
    }
}