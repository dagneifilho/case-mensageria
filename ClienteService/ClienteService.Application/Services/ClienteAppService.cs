using System;
using ClienteService.Application.DTO;
using ClienteService.Application.Interfaces;
using ClienteService.Domain.Entities;
using ClienteService.Domain.Enums;
using ClienteService.Domain.Events;
using ClienteService.Domain.Interfaces;

namespace ClienteService.Application.Services;

public class ClientesAppService : IClientesAppService
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IEventPublisher _eventPublisher;
    public ClientesAppService(IClienteRepository clienteRepository, IEventPublisher eventPublisher)
    {
        _clienteRepository = clienteRepository;
        _eventPublisher = eventPublisher;
    }
    public async Task<ClienteDto> CreateAsync(CreateClienteDto cliente)
    {
        Cliente clienteDb = new Cliente
        {
            Id = Guid.NewGuid(),
            Nome = cliente.Nome,
            Email = cliente.Email,
            Status = StatusCliente.EmProcessamento
        };

        clienteDb = await _clienteRepository.CreateAsync(clienteDb);

        await _eventPublisher.PublishAsync<ClienteCadastradoEvent>(new ClienteCadastradoEvent
        {
            Id = clienteDb.Id,
            Nome = clienteDb.Nome,
            Email = clienteDb.Email
        });

        return new ClienteDto
        {
            Id = clienteDb.Id,
            Nome = clienteDb.Nome,
            Email = clienteDb.Email,
            Status = clienteDb.Status
        };

    }

    protected virtual void Dispose(bool disposing)
    {
        _clienteRepository.Dispose();
        _eventPublisher.Dispose();
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

}
