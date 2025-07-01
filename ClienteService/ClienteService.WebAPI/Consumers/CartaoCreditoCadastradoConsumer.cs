using System;
using ClienteService.Application.Interfaces;
using MassTransit;
using Shared.Events;

namespace ClienteService.WebAPI.Consumers;

public class CartaoCreditoCadastradoConsumer : IConsumer<CartaoCreditoCadastradoEvent> 
{
    private readonly IClientesAppService _clienteAppService;
    private readonly ILogger<CartaoCreditoCadastradoConsumer> _logger;
    public CartaoCreditoCadastradoConsumer(IClientesAppService clientesAppService, ILogger<CartaoCreditoCadastradoConsumer> logger)
    {
        _clienteAppService = clientesAppService;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<CartaoCreditoCadastradoEvent> context)
    {
        var message = context.Message;

        _logger.LogInformation("Recebido evento Cartao Credito Cadastrado idCliente:" + message.ClienteId);

        await _clienteAppService.AtualizaCartaoCreditoCliente(message.ClienteId);
    }
}
