using AutoMapper;
using Core.Abstractions.Operations;
using CRUDoshlepok.Core.Mapper;
using CRUDoshlepok.Core.Operations;
using Microsoft.Extensions.DependencyInjection;

namespace CRUDoshlepok.Core;

public static class ServiceConfiguration
{
    public static void ConfigureCore(this IServiceCollection services)
    {
        services.AddScoped<IUserOperations, UserOperations>();
    }

    public static void ConfigureCoreProfiles(this IMapperConfigurationExpression mc)
    {
        mc.AddMaps(typeof(CoreProfile).Assembly);
    }

}