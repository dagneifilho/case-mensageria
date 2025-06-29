using System;
using CreditoService.Application.Interfaces;
using CreditoService.Domain.Entities;
using CreditoService.Domain.Interfaces;
using Shared.Events;

namespace CreditoService.Application.Services;

public class PropostaCreditoAppService : IPropostaCreditoAppService
{
    private readonly IPropostaCreditoRepository _propostaCreditoRepository;
    private readonly IEventPublisher _eventPublisher; 

    public PropostaCreditoAppService(IPropostaCreditoRepository propostaCreditoRepository, IEventPublisher eventPublisher)
    {
        _propostaCreditoRepository = propostaCreditoRepository;
        _eventPublisher = eventPublisher;
    }
    public async Task CriaPropostaCreditoAsync(Guid idCliente)
    {
        try
        {
            var cartao = new PropostaCredito
            {
                Id = Guid.NewGuid(),
                ClienteId = idCliente,
                Aprovado = true
            };

            await _propostaCreditoRepository.CreateAsync(cartao);

            await _eventPublisher.PublishAsync<PropostaCreditoCadastradaEvent>(new PropostaCreditoCadastradaEvent
            {
                ClienteId = idCliente
            });

        }
        catch (Exception ex)
        {
            await _eventPublisher.PublishAsync<PropostaCreditoErroEvent>(new PropostaCreditoErroEvent
            {
                ClienteId = idCliente,
                ErrorMessage = ex.Message
            });
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        _eventPublisher.Dispose();
        _propostaCreditoRepository.Dispose();
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
