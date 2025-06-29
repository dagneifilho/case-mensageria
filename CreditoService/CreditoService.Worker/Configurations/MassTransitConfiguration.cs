using System;
using CreditoService.Domain.Interfaces;
using CreditoService.Infrastructure.Messaging;
using CreditoService.Worker.Consumers;
using MassTransit;

namespace CreditoService.Worker.Configurations;

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

                cfg.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(5)));

                cfg.UseCircuitBreaker(cb =>
                {
                    cb.TrackingPeriod = TimeSpan.FromSeconds(30);
                    cb.TripThreshold = 20;
                    cb.ActiveThreshold = 5;
                    cb.ResetInterval = TimeSpan.FromSeconds(60);
                });

                cfg.ReceiveEndpoint("proposta.credito.queue", e =>
                {
                    e.ConfigureConsumer<ClienteCadastradoConsumer>(context);
                });

            });
            
        });
        services.AddScoped<IEventPublisher, MassTransitEventPublisher>();


        services.AddHostedService<MassTransitHostedService>();
    }
}
