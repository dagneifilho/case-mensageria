FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln .
COPY Shared/ Shared/
COPY ClienteService.WebAPI/ ClienteService.WebAPI/
COPY ClienteService.Application/ ClienteService.Application/
COPY ClienteService.Domain/ ClienteService.Domain/
COPY ClienteService.Infrastructure/ ClienteService.Infrastructure/

RUN dotnet restore

COPY . ./

WORKDIR /app/ClienteService.WebAPI
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "ClienteService.WebAPI.dll"]
