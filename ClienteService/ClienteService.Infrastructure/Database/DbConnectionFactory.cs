using System;
using System.Data;
using ClienteService.Domain.Interfaces;
using Npgsql;

namespace ClienteService.Infrastructure.Database;

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
