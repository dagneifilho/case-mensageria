using CreditoService.Worker.Configurations;
using CreditoService.Worker;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.ConfigureMassTransit();
builder.Services.AddIoCConfiguration();
builder.Services.ConfigureDatabase();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
