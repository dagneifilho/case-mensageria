using System;
using CartaoCreditoService.Worker.Consumers;
using MassTransit;

namespace CartaoCreditoService.Worker.Configurations;

public static class MassTransitConfiguration
{
    public static void ConfigureMassTransit(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<ClienteCadastradoConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint("proposta.credito.queue", e =>
                {
                    e.ConfigureConsumer<ClienteCadastradoConsumer>(context);
                });
            });
        });

        services.AddHostedService<MassTransitHostedService>();
    }
}
