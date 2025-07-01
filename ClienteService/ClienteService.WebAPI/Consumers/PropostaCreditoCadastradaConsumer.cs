using System;
using ClienteService.Application.Interfaces;
using MassTransit;
using Shared.Events;

namespace ClienteService.WebAPI.Consumers;

public class PropostaCreditoCadastradaConsumer : IConsumer<PropostaCreditoCadastradaEvent>
{
    private readonly IClientesAppService _clienteAppService;
    private readonly ILogger<PropostaCreditoCadastradaConsumer> _logger;
    public PropostaCreditoCadastradaConsumer(IClientesAppService clientesAppService, ILogger<PropostaCreditoCadastradaConsumer> logger)
    {
        _clienteAppService = clientesAppService;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<PropostaCreditoCadastradaEvent> context)
    {
        var message = context.Message;

        _logger.LogInformation("Recebido evento Proposta de Credito Cadastrada idCliente:" + message.ClienteId);

        await _clienteAppService.AtualizaPropostaCreditoCliente(message.ClienteId);
    }
}
