using System;
using ClienteService.Application.Interfaces;
using MassTransit;
using Shared.Events;

namespace ClienteService.WebAPI.Consumers;

public class PropostaCreditoErroConsumer : IConsumer<PropostaCreditoErroEvent>
{
    private readonly IClientesAppService _clienteAppService;
    private readonly ILogger<PropostaCreditoErroConsumer> _logger;
    public PropostaCreditoErroConsumer(IClientesAppService clientesAppService, ILogger<PropostaCreditoErroConsumer> logger)
    {
        _clienteAppService = clientesAppService;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<PropostaCreditoErroEvent> context)
    {
        var message = context.Message;

        _logger.LogInformation("Recebido evento Proposta de Credito com erro idCliente:" + message.ClienteId);

        await _clienteAppService.AtualizaPropostaCreditoCliente(message.ClienteId);
    }
}
