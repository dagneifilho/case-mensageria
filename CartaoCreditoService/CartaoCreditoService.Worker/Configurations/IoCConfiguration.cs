using System;
using CartaoCreditoService.Application.Interfaces;
using CartaoCreditoService.Application.Services;
using CartaoCreditoService.Domain.Interfaces;
using CartaoCreditoService.Infrastructure.Repositories;

namespace CartaoCreditoService.Worker.Configurations;
public static class IoCConfiguration
{
    public static void AddIoCConfiguration(this IServiceCollection services)
    {
        //Services
        services.AddScoped<ICartaoCreditoAppService, CartaoCreditoAppService>();

        //Repositories
        services.AddScoped<ICartaoCreditoRepository, CartaoCreditoRepository>();
    
    }
}
