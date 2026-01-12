using AutoMapper;
using CRUDoshlepok.Dal.Context;
using CRUDoshlepok.Dal.Mapper;
using CRUDoshlepok.Dal.Repositories;
using Dal.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRUDoshlepok.Dal;

public static class DatabaseConfiguration
{
    public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration,
        bool inMemory = false, string? databaseName = null)
    {
        if (inMemory)
        {
            services.AddDbContext<CrudoshlepokDbContext>(options => options
                .UseInMemoryDatabase(databaseName: databaseName ?? nameof(CrudoshlepokDbContext)));
        }
        else
        {
            services.AddDbContext<CrudoshlepokDbContext>(options => options
                .UseLazyLoadingProxies()
                .UseNpgsql(configuration.GetConnectionString(CrudoshlepokDbContext.ConnectionDatabase)));
        }

        services.AddScoped<IModelUpdater>(x =>
        {
            var context = x.GetRequiredService<CrudoshlepokDbContext>();
            return context;
        });
        
        services.AddScoped<IModelReader>(x =>
        {
            var context = x.GetRequiredService<CrudoshlepokDbContext>();
            return context;
        });

        services.AddScoped<IUserRepository, UserRepository>();
    }

    public static void MigrateDb(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var model = scope.ServiceProvider.GetRequiredService<CrudoshlepokDbContext>();
        
        if (!model.Database.CanConnect())
        {
            throw new Exception("No connect to database");
        }

        model.Database.Migrate();
    }

    public static void ConfigureDalProfiles(this IMapperConfigurationExpression mc)
    {
        mc.AddMaps(typeof(DalProfile).Assembly);
    }
}