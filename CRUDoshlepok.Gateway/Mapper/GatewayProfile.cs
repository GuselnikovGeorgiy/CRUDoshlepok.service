using AutoMapper;
using Core.Abstractions.Models;
using CRUDoshlepok.Gateway.Models.User;

namespace CRUDoshlepok.Gateway.Mapper;

internal sealed class GatewayProfile : Profile
{
    public GatewayProfile()
    {
        CreateMap<AddUserDto, AddUserOperationModel>();
        CreateMap<UserOperationModel, ResultAddUserDto>();
    }
}