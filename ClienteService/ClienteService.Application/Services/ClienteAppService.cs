using System;
using System.Reflection.Metadata;
using ClienteService.Application.DTO;
using ClienteService.Application.Interfaces;
using ClienteService.Domain.Entities;
using ClienteService.Domain.Enums;
using ClienteService.Domain.Interfaces;
using Shared.Events;

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
            StatusCartao = Status.EmProcessamento.ToString(),
            StatusProposta = Status.EmProcessamento.ToString()
        };

    }

    public async Task<IList<ClienteDetalhadoDto>> GetAll()
    {
        var clientesDb = await _clienteRepository.GetAllAsync();

        var clientes = clientesDb.Select<ClienteDetalhado, ClienteDetalhadoDto>(c =>
        {
            return new ClienteDetalhadoDto
            {
                Id = c.ClienteId,
                Nome = c.Nome,
                Email = c.Email,
                StatusCartao = c.StatusCartao.ToString(),
                StatusProposta = c.StatusProposta.ToString(),
                CartaoId = c.CartaoId,
                NumeroCartao = c.NumeroCartao,
                AprovacaoId = c.AprovacaoId
            };
        }).ToList();

        return clientes;
    }


    public async Task AtualizaCartaoCreditoCliente(Guid clienteId, bool sucesso = true)
    {
        var cliente = await _clienteRepository.GetByIdAsync(clienteId);

        if (cliente is null)
            throw new KeyNotFoundException("Cliente não encontrado");

        cliente.StatusCartao = sucesso ? Status.ProcessadoComSucesso : Status.ErroNoProcessamento;
        await _clienteRepository.UpdateAsync(cliente);

    }

    public async Task AtualizaPropostaCreditoCliente(Guid clienteId, bool sucesso = true)
    {
        var cliente = await _clienteRepository.GetByIdAsync(clienteId);

        if (cliente is null)
            throw new KeyNotFoundException("Cliente não encontrado");

        cliente.StatusProposta = sucesso ? Status.ProcessadoComSucesso : Status.ErroNoProcessamento;
        await _clienteRepository.UpdateAsync(cliente);
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
