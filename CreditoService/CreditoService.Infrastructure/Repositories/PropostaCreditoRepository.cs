using System;
using System.Data;
using CreditoService.Domain.Entities;
using CreditoService.Domain.Interfaces;
using CartaoCredtoService.Domain.Interfaces;
using Dapper;

namespace CreditoService.Infrastructure.Repositories;

public class PropostaCreditoRepository : IPropostaCreditoRepository
{
    private readonly IDbConnection _connection;
    public PropostaCreditoRepository(IDbConnectionFactory connectionFactory)
    {
        _connection = connectionFactory.CreateConnection();
    }
    public async Task CreateAsync(PropostaCredito cartao)
    {
        DynamicParameters parameters = new DynamicParameters();
        var query = @"INSERT INTO aprovacoes_credito
            (
                id,
                cliente_id,
                aprovado
            )
            VALUES (
                @id,
                @cliente_id,
                @aprovado
            );
        ";
        parameters.Add("@id", cartao.Id, DbType.Guid, ParameterDirection.Input);
        parameters.Add("@cliente_id", cartao.ClienteId, DbType.Guid, ParameterDirection.Input);
        parameters.Add("@aprovado", cartao.Aprovado, DbType.Boolean, ParameterDirection.Input);

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
