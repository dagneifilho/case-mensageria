using System;
using ClienteService.Domain.Interfaces;
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
                config.Message<IClienteCadastradoEvent>(x =>
                {
                    x.SetEntityName("cliente.exchange");
                });
            });
        });
    }
}
