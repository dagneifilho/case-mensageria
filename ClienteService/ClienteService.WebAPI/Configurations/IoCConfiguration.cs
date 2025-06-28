using System;
using ClienteService.Application.Interfaces;
using ClienteService.Application.Services;
using ClienteService.Domain.Interfaces;
using ClienteService.Infrastructure.Repositories;

namespace ClienteService.WebAPI.Configurations;

public static class IoCConfiguration
{
    public static void AddIoCConfiguration(this IServiceCollection services)
    {
        //Services
        services.AddScoped<IClientesAppService, ClientesAppService>();

        //Repositories
        services.AddScoped<IClienteRepository, ClienteRepository>();
    }
}
