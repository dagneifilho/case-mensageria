using System;
using ClienteService.Domain.Interfaces;
using ClienteService.Infrastructure.Messaging;
using MassTransit;

namespace ClienteService.WebAPI.Configurations;

public static class MassTransitConfig
{
    public static void AddMassTransitConfiguration(this IServiceCollection services)
    {
        
        services.AddMassTransit(x =>
        {            
            x.UsingRabbitMq((context, config) =>
            {
                config.Host("localhost", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
                config.ConfigureEndpoints(context);
            });
        });

        services.AddScoped<IEventPublisher, MassTransitEventPublisher>();
    }
}

