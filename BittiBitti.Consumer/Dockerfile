#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BittiBitti.Consumer/BittiBitti.Consumer.csproj", "BittiBitti.Consumer/"]
COPY ["BittiBitti.Core/BittiBitti.Core.csproj", "BittiBitti.Core/"]
COPY ["BittiBitti.Application/BittiBitti.Application.csproj", "BittiBitti.Application/"]
COPY ["BittiBitti.Publisher/BittiBitti.Publisher.csproj", "BittiBitti.Publisher/"]
COPY ["BittiBitti.Domain/BittiBitti.Domain.csproj", "BittiBitti.Domain/"]
RUN dotnet restore "BittiBitti.Consumer/BittiBitti.Consumer.csproj"
COPY . .
WORKDIR "/src/BittiBitti.Consumer"
RUN dotnet build "BittiBitti.Consumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BittiBitti.Consumer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BittiBitti.Consumer.dll"]