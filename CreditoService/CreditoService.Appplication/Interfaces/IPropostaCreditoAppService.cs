using System;

namespace CreditoService.Application.Interfaces;

public interface IPropostaCreditoAppService : IDisposable
{
    Task CriaPropostaCreditoAsync(Guid idCliente);
}
