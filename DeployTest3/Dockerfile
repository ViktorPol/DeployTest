#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DeployTest3/DeployTest3.csproj", "DeployTest3/"]
RUN dotnet restore "DeployTest3/DeployTest3.csproj"
COPY . .
WORKDIR "/src/DeployTest3"
RUN dotnet build "DeployTest3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DeployTest3.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DeployTest3.dll"]