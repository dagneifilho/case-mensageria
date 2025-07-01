using System;
using ClienteService.Domain.Entities;

namespace ClienteService.Domain.Interfaces;

public interface IClienteRepository : IDisposable
{
    Task<Cliente> CreateAsync(Cliente cliente);
    Task<Cliente> GetByIdAsync(Guid clienteId);
    Task UpdateAsync(Cliente cliente);
    Task<IList<ClienteDetalhado>> GetAllAsync();
}
