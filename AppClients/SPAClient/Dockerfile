FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base

WORKDIR /app
EXPOSE 80
EXPOSE 443
#EXPOSE 5104
#EXPOSE 5000
#EXPOSE 60191
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
# Install NodeJs
RUN apt-get update && \
apt-get install -y wget && \
apt-get install -y gnupg2 && \
wget -qO- https://deb.nodesource.com/setup_12.x | bash - && \
apt-get install -y build-essential nodejs
# End Install
WORKDIR /src
COPY ["AppClients/SPAClient/SPAClient.csproj", "AppClients/SPAClient/"]
RUN dotnet restore "AppClients/SPAClient/SPAClient.csproj"
COPY . .
WORKDIR "/src/AppClients/SPAClient"
RUN dotnet build "SPAClient.csproj" -c Release -o /app/build



FROM build AS publish
RUN dotnet publish "SPAClient.csproj" -c Release -o /app/publish

WORKDIR "/src/AppClients/SPAClient/ClientApp"
COPY ["AppClients/SPAClient/ClientApp/package.json", "AppClients/SPAClient/ClientApp/"]
COPY ["AppClients/SPAClient/ClientApp/package-lock.json", "AppClients/SPAClient/ClientApp/"]
COPY . .
RUN npm install
RUN npm run build -- --prod

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "SPAClient.dll"]