#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["./LocaCar.Api/LocaCar.Api.csproj", "LocaCar.Api/LocaCar.Api.csproj"]
COPY ["./LocaCar.Business/LocaCar.Business.csproj", "LocaCar.Api/LocaCar.Business.csproj"]
COPY ["./LocaCar.Data/LocaCar.Data.csproj", "LocaCar.Api/LocaCar.Data.csproj"]
RUN dotnet restore "LocaCar.Api/LocaCar.Api.csproj"
COPY . .
WORKDIR "LocaCar.Api"
RUN dotnet build "LocaCar.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LocaCar.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LocaCar.Api.dll"]