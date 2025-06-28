using System;
using MassTransit;
using Shared;
using Shared.Events;

namespace CartaoCreditoService.Worker.Consumers;

public class ClienteCadastradoConsumer : IConsumer<ClienteCadastradoEvent>
{
    public Task Consume(ConsumeContext<ClienteCadastradoEvent> context)
    {

        var message = context.Message;
        Console.WriteLine(message.Nome);
        Console.WriteLine(message.Email);
        return Task.CompletedTask;

    }

}
