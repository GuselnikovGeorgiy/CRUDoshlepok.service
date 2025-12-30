using AutoMapper;
using CRUDoshlepok.Dal.Tables;
using Dal.Abstractions.Models;

namespace CRUDoshlepok.Dal.Mapper;

public class DalProfile : Profile
{
    public DalProfile()
    {
        CreateMap<UserRepositoryModel, User>().ReverseMap();
    }
}