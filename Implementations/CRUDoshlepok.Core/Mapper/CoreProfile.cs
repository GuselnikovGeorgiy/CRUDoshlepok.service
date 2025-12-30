using AutoMapper;
using Core.Abstractions.Models;
using Dal.Abstractions.Models;

namespace CRUDoshlepok.Core.Mapper;

public class CoreProfile : Profile
{
    public CoreProfile()
    {
        CreateMap<UserOperationModel, UserRepositoryModel>();
    }
}