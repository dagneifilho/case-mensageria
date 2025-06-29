using System;
using CreditoService.Domain.Entities;

namespace CreditoService.Domain.Interfaces;

public interface IPropostaCreditoRepository : IDisposable
{
    public Task CreateAsync(PropostaCredito cartao);
}
