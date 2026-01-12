using AutoMapper;
using CRUDoshlepok.Dal.Tables;
using Dal.Abstractions.Models;

namespace CRUDoshlepok.Dal.Mapper;

public class DalProfile : Profile
{
    public DalProfile()
    {
        CreateMap<AddUserRepositoryModel, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ReverseMap();
        CreateMap<UserRepositoryModel, User>().ReverseMap();
    }
}