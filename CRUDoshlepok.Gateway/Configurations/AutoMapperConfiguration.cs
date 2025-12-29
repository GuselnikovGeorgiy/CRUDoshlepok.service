using AutoMapper;
using CRUDoshlepok.Gateway.Mapper;

namespace CRUDoshlepok.Gateway.Configurations;

internal static class AutoMapperConfiguration
{
    public static void ConfigureAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg =>
        {
            cfg.ConfigureGatewayProfiles();
            // cfg.ConfigureDalProfiles();
        });
    }
    
    public static void ValidateMapperProfiles(this IServiceProvider serviceProvider)
    {
        serviceProvider.GetRequiredService<IMapper>()
            .ConfigurationProvider
            .AssertConfigurationIsValid();
    }
    
    private static void ConfigureGatewayProfiles(this IMapperConfigurationExpression mc)
    {
        mc.AddMaps(typeof(GatewayProfile).Assembly);
    }
}