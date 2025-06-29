using System;
using CartaoCreditoService.Application.Interfaces;
using MassTransit;
using Shared.Events;

namespace CartaoCreditoService.Worker.Consumers;

public class ClienteCadastradoConsumer : IConsumer<ClienteCadastradoEvent>
{
    private readonly ICartaoCreditoAppService _cartaoCreditoAppService;
    private readonly ILogger<ClienteCadastradoConsumer> _logger;
    public ClienteCadastradoConsumer(ICartaoCreditoAppService cartaoCreditoAppService, ILogger<ClienteCadastradoConsumer> logger)
    {
        _cartaoCreditoAppService = cartaoCreditoAppService;
        _logger = logger;
    }
    public async Task Consume(ConsumeContext<ClienteCadastradoEvent> context)
    {
        var message = context.Message;

        _logger.LogInformation("Cliente recebido: "+message.Id);

        await _cartaoCreditoAppService.CriaCartaoCreditoAsync(message.Id);
    }

}
