using System;
using ClienteService.Application.DTO;

namespace ClienteService.Application.Interfaces;

public interface IClientesAppService : IDisposable
{
    Task<ClienteDto> CreateAsync(CreateClienteDto cliente);
    Task AtualizaCartaoCreditoCliente(Guid clienteId, bool sucesso = true);
    Task AtualizaPropostaCreditoCliente(Guid clienteId, bool sucesso = true);
    Task<IList<ClienteDetalhadoDto>> GetAll();
}
