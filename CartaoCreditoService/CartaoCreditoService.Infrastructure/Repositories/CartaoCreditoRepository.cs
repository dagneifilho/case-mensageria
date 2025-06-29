using System;
using System.Data;
using CartaoCreditoService.Domain.Entities;
using CartaoCreditoService.Domain.Interfaces;
using CartaoCredtoService.Domain.Interfaces;
using Dapper;

namespace CartaoCreditoService.Infrastructure.Repositories;

public class CartaoCreditoRepository : ICartaoCreditoRepository
{
    private readonly IDbConnection _connection;
    public CartaoCreditoRepository(IDbConnectionFactory connectionFactory)
    {
        _connection = connectionFactory.CreateConnection();
    }
    public async Task CreateAsync(CartaoCredito cartao)
    {
        DynamicParameters parameters = new DynamicParameters();
        var query = @"INSERT INTO cartoes_credito
            (
                id,
                cliente_id,
                numero_cartao,
                validade
            )
            VALUES (
                @id,
                @cliente_id,
                @numero_cartao,
                @validade
            );
        ";
        parameters.Add("@id", cartao.Id, DbType.Guid, ParameterDirection.Input);
        parameters.Add("@cliente_id", cartao.ClienteId, DbType.Guid, ParameterDirection.Input);
        parameters.Add("@numero_cartao", cartao.NumeroCartao, DbType.String, ParameterDirection.Input);
        parameters.Add("@validade", cartao.Validade, DbType.DateTime, ParameterDirection.Input);

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
