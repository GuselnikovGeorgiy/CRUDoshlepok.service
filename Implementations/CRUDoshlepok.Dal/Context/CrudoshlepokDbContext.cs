using CRUDoshlepok.Dal.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CRUDoshlepok.Dal.Context;

internal class CrudoshlepokDbContext : DbContext, IModelReader, IModelUpdater
{
    public const string ConnectionDatabase = "PostgresCN";
    
    
    public CrudoshlepokDbContext()
    {
    }

    public CrudoshlepokDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    
    IQueryable<User> IModelReader.Users => Users.AsNoTracking();
    
    async Task<int> IModelUpdater.SaveChangesAsync() => await SaveChangesAsync();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),"..", "..", "CRUDoshlepok.Gateway"))
                .AddJsonFile("appsettings.Development.json")
                .Build();
            var connectionString = configuration.GetConnectionString(ConnectionDatabase);
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseNpgsql(connectionString);
        }
        
        base.OnConfiguring(optionsBuilder);
    }
}