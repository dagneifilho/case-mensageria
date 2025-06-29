using System;
using System.Data;
using CartaoCredtoService.Domain.Interfaces;
using Npgsql;

namespace CartaoCreditoService.Infrastructure.Database;

public class DbConnectionFactory : IDbConnectionFactory
{
    private readonly DbConfig _dbConfig;

    public DbConnectionFactory(DbConfig dbConfig) {
        _dbConfig = dbConfig;
    }
    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(_dbConfig.ConnectionString);
    }
}
