using System;
using ClienteService.Application.DTO;

namespace ClienteService.Application.Interfaces;

public interface IClientesAppService : IDisposable
{
    Task<ClienteDto> CreateAsync(CreateClienteDto cliente);
}
