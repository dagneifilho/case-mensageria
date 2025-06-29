using System;
using CreditoService.Application.Interfaces;
using CreditoService.Application.Services;
using CreditoService.Domain.Interfaces;
using CreditoService.Infrastructure.Repositories;

namespace CreditoService.Worker.Configurations;

public static class IoCConfiguration
{
    public static void AddIoCConfiguration(this IServiceCollection services)
    {
        //Services
        services.AddScoped<IPropostaCreditoAppService, PropostaCreditoAppService>();

        //Repositories
        services.AddScoped<IPropostaCreditoRepository, PropostaCreditoRepository>();
    
    }
}
