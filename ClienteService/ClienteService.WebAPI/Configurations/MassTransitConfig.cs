using System;
using ClienteService.Domain.Interfaces;
using ClienteService.Infrastructure.Messaging;
using ClienteService.WebAPI.Consumers;
using MassTransit;

namespace ClienteService.WebAPI.Configurations;

public static class MassTransitConfig
{
    public static void AddMassTransitConfiguration(this IServiceCollection services)
    {
        
        services.AddMassTransit(x =>
        {
            x.AddConsumer<CartaoCreditoCadastradoConsumer>();
            x.AddConsumer<CartaoCreditoErroConsumer>();
            x.AddConsumer<PropostaCreditoCadastradaConsumer>();
            x.AddConsumer<PropostaCreditoErroConsumer>();
            x.UsingRabbitMq((context, config) =>
            {
                config.Host("localhost", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                config.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(5)));

                config.UseCircuitBreaker(cb =>
                {
                    cb.TrackingPeriod = TimeSpan.FromSeconds(30);
                    cb.TripThreshold = 20;
                    cb.ActiveThreshold = 5;
                    cb.ResetInterval = TimeSpan.FromSeconds(60);
                });


                config.ReceiveEndpoint("cartao.credito.cadastrado.queue", e =>
                {
                    e.ConfigureConsumer<CartaoCreditoCadastradoConsumer>(context);
                });
                config.ReceiveEndpoint("cartao.credito.erro.queue", e =>
                {
                    e.ConfigureConsumer<CartaoCreditoErroConsumer>(context);
                });
                config.ReceiveEndpoint("proposta.credito.cadastrada.queue", e =>
                {
                    e.ConfigureConsumer<PropostaCreditoCadastradaConsumer>(context);
                });
                config.ReceiveEndpoint("proposta.credito.erro.queue", e =>
                {
                    e.ConfigureConsumer<PropostaCreditoErroConsumer>(context);
                });


            });
            
        });

        services.AddScoped<IEventPublisher, MassTransitEventPublisher>();
    }
}

