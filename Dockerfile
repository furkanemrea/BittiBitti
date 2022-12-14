

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BittiBitti.API/BittiBitti.API.csproj", "BittiBitti.API/"]
COPY ["BittiBitti.Core/BittiBitti.Core.csproj", "BittiBitti.Core/"]
COPY ["BittiBitti.Persistence/BittiBitti.Persistence.csproj", "BittiBitti.Persistence/"]
COPY ["BittiBitti.Domain/BittiBitti.Domain.csproj", "BittiBitti.Domain/"]
COPY ["BittiBitti.Application/BittiBitti.Application.csproj", "BittiBitti.Application/"]

RUN dotnet restore "BittiBitti.API/BittiBitti.API.csproj"
COPY . .
WORKDIR "/src/BittiBitti.API"
RUN dotnet build "BittiBitti.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BittiBitti.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BittiBitti.API.dll"]



