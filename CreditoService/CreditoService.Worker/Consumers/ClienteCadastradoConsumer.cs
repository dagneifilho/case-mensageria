using System;
using CreditoService.Application.Interfaces;
using MassTransit;
using Shared;
using Shared.Events;

namespace CreditoService.Worker.Consumers;

public class ClienteCadastradoConsumer : IConsumer<ClienteCadastradoEvent>
{
    private readonly IPropostaCreditoAppService _propostaCreditoAppService;
    private readonly ILogger<ClienteCadastradoConsumer> _logger;
    public ClienteCadastradoConsumer(IPropostaCreditoAppService propostaCreditoAppService, ILogger<ClienteCadastradoConsumer> logger)
    {
        _propostaCreditoAppService = propostaCreditoAppService;
        _logger = logger;
    }
    public async Task Consume(ConsumeContext<ClienteCadastradoEvent> context)
    {
        var message = context.Message;

        _logger.LogInformation("Cliente recebido: "+message.Id);

        await _propostaCreditoAppService.CriaPropostaCreditoAsync(message.Id);
    }

}
