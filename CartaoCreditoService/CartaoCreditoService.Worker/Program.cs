using CartaoCreditoService.Worker;
using CartaoCreditoService.Worker.Configurations;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.ConfigureMassTransit();
builder.Services.AddHostedService<Worker>();
var host = builder.Build();
host.Run();
