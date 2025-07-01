FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln .
COPY Shared/ Shared/
COPY CartaoCreditoService.Worker/ CartaoCreditoService.Worker/
COPY CartaoCreditoService.Application/ CartaoCreditoService.Application/
COPY CartaoCreditoService.Domain/ CartaoCreditoService.Domain/
COPY CartaoCreditoService.Infrastructure/ CartaoCreditoService.Infrastructure/

RUN dotnet restore

COPY . ./

WORKDIR /app/CartaoCreditoService.Worker
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "CartaoCreditoService.Worker.dll"]
