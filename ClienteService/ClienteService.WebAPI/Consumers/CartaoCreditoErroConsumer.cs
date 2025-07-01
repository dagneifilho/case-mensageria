using System;
using ClienteService.Application.Interfaces;
using MassTransit;
using Shared.Events;

namespace ClienteService.WebAPI.Consumers;

public class CartaoCreditoErroConsumer : IConsumer<CartaoCreditoErroEvent>
{
    private readonly IClientesAppService _clienteAppService;
    private readonly ILogger<CartaoCreditoErroConsumer> _logger;
    public CartaoCreditoErroConsumer(IClientesAppService clientesAppService, ILogger<CartaoCreditoErroConsumer> logger)
    {
        _clienteAppService = clientesAppService;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<CartaoCreditoErroEvent> context)
    {
        var message = context.Message;

        _logger.LogInformation("Recebido evento Cartao Credito com erro idCliente:" + message.ClienteId);

        await _clienteAppService.AtualizaCartaoCreditoCliente(message.ClienteId, false);
    }
}
