using System;
using CreditoService.Infrastructure.Database;
using CartaoCredtoService.Domain.Interfaces;

namespace CreditoService.Worker.Configurations;


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

