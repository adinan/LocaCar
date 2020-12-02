#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/LocaCar.Api/LocaCar.Api.csproj", "src/LocaCar.Api/"]
RUN dotnet restore "src/LocaCar.Api/LocaCar.Api.csproj"
COPY . .
WORKDIR "/src/src/LocaCar.Api"
RUN dotnet build "LocaCar.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LocaCar.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LocaCar.Api.dll"]