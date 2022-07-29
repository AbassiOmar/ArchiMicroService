#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Invoice/InvoiceApi/InvoiceApi.csproj", "Invoice/InvoiceApi/"]
COPY ["Invoice/Invocie.Core/Invocie.Core.csproj", "Invoice/Invocie.Core/"]
COPY ["Invoice/Invoice.Domain/Invoice.Domain.csproj", "Invoice/Invoice.Domain/"]
COPY ["CrossCuttings/EventBus/EventBus.csproj", "CrossCuttings/EventBus/"]
COPY ["Invoice/Invoice.Infrastructure/Invoice.Infrastructure.csproj", "Invoice/Invoice.Infrastructure/"]
COPY ["CrossCuttings/LoggingLibrary/LoggingLibrary.csproj", "CrossCuttings/LoggingLibrary/"]
RUN dotnet restore "Invoice/InvoiceApi/InvoiceApi.csproj"
COPY . .
WORKDIR "/src/Invoice/InvoiceApi"
RUN dotnet build "InvoiceApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InvoiceApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InvoiceApi.dll"]