using System;
using System.Data;
using ClienteService.Domain.Entities;
using ClienteService.Domain.Interfaces;
using Dapper;

namespace ClienteService.Infrastructure.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly IDbConnection _connection;
    public ClienteRepository(IDbConnectionFactory connectionFactory)
    {
        _connection = connectionFactory.CreateConnection();
    }
    public async Task<Cliente> CreateAsync(Cliente cliente)
    {
        DynamicParameters parameters = new DynamicParameters();
        var query = @"INSERT INTO clientes
            (
                Id,
                Nome,
                Email,
                Status
            )
            VALUES (
                @id,
                @nome,
                @email,
                @status
            );
        ";
        parameters.Add("@id", cliente.Id, DbType.Guid, ParameterDirection.Input);
        parameters.Add("@nome", cliente.Nome, DbType.String, ParameterDirection.Input);
        parameters.Add("@email", cliente.Email, DbType.String, ParameterDirection.Input);
        parameters.Add("@status", cliente.Status, DbType.Int32, ParameterDirection.Input);

        await _connection.ExecuteAsync(query, parameters);

        return cliente;
    }

    protected virtual void Dispose(bool disposing)
    {
        _connection.Dispose();
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
