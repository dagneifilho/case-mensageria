using System;
using CartaoCreditoService.Application.Interfaces;
using CartaoCreditoService.Domain.Entities;
using CartaoCreditoService.Domain.Interfaces;
using Shared.Events;

namespace CartaoCreditoService.Application.Services;

public class CartaoCreditoAppService : ICartaoCreditoAppService
{
    private readonly ICartaoCreditoRepository _cartaoCreditoRepository;
    private readonly IEventPublisher _eventPublisher; 

    public CartaoCreditoAppService(ICartaoCreditoRepository cartaoCreditoRepository, IEventPublisher eventPublisher)
    {
        _cartaoCreditoRepository = cartaoCreditoRepository;
        _eventPublisher = eventPublisher;
    }
    public async Task CriaCartaoCreditoAsync(Guid idCliente)
    {
        try
        {
            var cartao = new CartaoCredito
            {
                Id = Guid.NewGuid(),
                ClienteId = idCliente,
                Validade = DateTime.UtcNow.AddYears(4)
            };
            cartao.GerarNumeroCartao();

            await _cartaoCreditoRepository.CreateAsync(cartao);

            await _eventPublisher.PublishAsync<CartaoCreditoCadastradoEvent>(new CartaoCreditoCadastradoEvent
            {
                ClienteId = idCliente
            });

        }
        catch (Exception ex)
        {
            await _eventPublisher.PublishAsync<CartaoCreditoErroEvent>(new CartaoCreditoErroEvent
            {
                ClienteId = idCliente,
                ErrorMessage = ex.Message
            });
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        _eventPublisher.Dispose();
        _cartaoCreditoRepository.Dispose();
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
