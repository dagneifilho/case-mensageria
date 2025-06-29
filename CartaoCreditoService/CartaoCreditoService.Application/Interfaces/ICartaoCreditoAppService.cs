using System;

namespace CartaoCreditoService.Application.Interfaces;

public interface ICartaoCreditoAppService : IDisposable
{
    Task CriaCartaoCreditoAsync(Guid idCliente);
}
