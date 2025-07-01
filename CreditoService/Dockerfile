FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln .
COPY Shared/ Shared/
COPY CreditoService.Worker/ CreditoService.Worker/
COPY CreditoService.Appplication/ CreditoService.Appplication/
COPY CreditoService.Domain/ CreditoService.Domain/
COPY CreditoService.Infrastructure/ CreditoService.Infrastructure/

RUN dotnet restore

COPY . ./

WORKDIR /app/CreditoService.Worker
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "CreditoService.Worker.dll"]
