using System;
using CartaoCreditoService.Domain.Entities;

namespace CartaoCreditoService.Domain.Interfaces;

public interface ICartaoCreditoRepository : IDisposable
{
    public Task CreateAsync(CartaoCredito cartao);
}
