using System;
using CartaoCreditoService.Infrastructure.Database;
using CartaoCredtoService.Domain.Interfaces;

namespace CartaoCreditoService.Worker.Configurations;


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

