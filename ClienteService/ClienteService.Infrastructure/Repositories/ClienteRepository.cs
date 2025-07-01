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
                Email
            )
            VALUES (
                @id,
                @nome,
                @email
            );
        ";
        parameters.Add("@id", cliente.Id, DbType.Guid, ParameterDirection.Input);
        parameters.Add("@nome", cliente.Nome, DbType.String, ParameterDirection.Input);
        parameters.Add("@email", cliente.Email, DbType.String, ParameterDirection.Input);

        await _connection.ExecuteAsync(query, parameters);

        return cliente;
    }

    public async Task<Cliente> GetByIdAsync(Guid clienteId)
    {
        DynamicParameters parameters = new();
        var query = @"
            SELECT  
                id as Id,
                nome as Nome,
                email as Email,
                status_cartao as StatusCartao,
                status_proposta as StatusProposta
            FROM clientes
            WHERE id = @id;
        ";
        parameters.Add("@id", clienteId, DbType.Guid, ParameterDirection.Input);


        var result = await _connection.QueryFirstOrDefaultAsync<Cliente>(query, parameters);
        return result;
    }
    public async Task UpdateAsync(Cliente cliente)
    {
        DynamicParameters parameters = new();
        var query = @" UPDATE clientes
            SET
                nome = @nome,
                email = @email,
                status_cartao = @statusCartao,       
                status_proposta = @statusProposta      
            WHERE Id = @id;        
        ";

        parameters.Add("@id", cliente.Id, DbType.Guid, ParameterDirection.Input);
        parameters.Add("@nome", cliente.Nome, DbType.String, ParameterDirection.Input);
        parameters.Add("@email", cliente.Email, DbType.String, ParameterDirection.Input);
        parameters.Add("@statusCartao", cliente.StatusCartao, DbType.Int32, ParameterDirection.Input);
        parameters.Add("@statusProposta", cliente.StatusProposta, DbType.Int32, ParameterDirection.Input);

        await _connection.ExecuteAsync(query, parameters);
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
