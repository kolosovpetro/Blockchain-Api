#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["BlockchainAPI.Core/BlockchainAPI.Core.csproj", "BlockchainAPI.Core/"]
COPY ["BlockchainAPI.Responses/BlockchainAPI.Responses.csproj", "BlockchainAPI.Responses/"]
COPY ["BlockchainAPI.Blockchain/BlockchainAPI.Blockchain.csproj", "BlockchainAPI.Blockchain/"]
COPY ["BlockchainAPI.Block/BlockchainAPI.Block.csproj", "BlockchainAPI.Block/"]
COPY ["BlockchainAPI.Transactions/BlockchainAPI.Transactions.csproj", "BlockchainAPI.Transactions/"]
COPY ["BlockchainAPI.Repository/BlockchainAPI.Repository.csproj", "BlockchainAPI.Repository/"]
RUN dotnet restore "BlockchainAPI.Core/BlockchainAPI.Core.csproj"
COPY . .
WORKDIR "/src/BlockchainAPI.Core"
RUN dotnet build "BlockchainAPI.Core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlockchainAPI.Core.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "BlockchainAPI.Core.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet BlockchainAPI.Core.dll