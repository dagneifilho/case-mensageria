using System;
using ClienteService.Domain.Interfaces;
using ClienteService.Infrastructure.Database;

namespace ClienteService.WebAPI.Configurations;

public static class DatabaseConfiguration
{
    public static void ConfigureDatabase(this IServiceCollection services)
    {
        var connectionString = Environment.GetEnvironmentVariable("postgre");
        services.AddSingleton<DbConfig>(new DbConfig
        {
            ConnectionString = connectionString
        });
        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
    }
}
