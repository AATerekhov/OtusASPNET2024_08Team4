# См. статью по ссылке https://aka.ms/customizecontainer, чтобы узнать как настроить контейнер отладки и как Visual Studio использует этот Dockerfile для создания образов для ускорения отладки.

# Этот этап используется при запуске из VS в быстром режиме (по умолчанию для конфигурации отладки)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# Этот этап используется для сборки проекта службы
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Broadcaster/Broadcaster.csproj", "Broadcaster/"]
COPY ["Broadcaster.Application.Service.Abstractions/Broadcaster.Application.Services.Abstractions.csproj", "Broadcaster.Application.Service.Abstractions/"]
COPY ["Broadcaster.Application.Models/Broadcaster.Application.Models.csproj", "Broadcaster.Application.Models/"]
COPY ["Broadcaster.Application.Services.Implementations/Broadcaster.Application.Services.Implementations.csproj", "Broadcaster.Application.Services.Implementations/"]
COPY ["BroadcasterMicroservice.Domain.Repository.Abstractions/BroadcasterMicroservice.Domain.Repository.Abstractions.csproj", "BroadcasterMicroservice.Domain.Repository.Abstractions/"]
COPY ["BroadcasterService.Domain.Entity/BroadcasterMicroservice.Domain.Entity.csproj", "BroadcasterService.Domain.Entity/"]
COPY ["BroadcasterMicroservice.Domain.ValueObject/BroadcasterMicroservice.Domain.ValueObject.csproj", "BroadcasterMicroservice.Domain.ValueObject/"]
COPY ["BroadcasterMicroservice.Infrastructure.Implementations/BroadcasterMicroservice.Infrastructure.Implementations.csproj", "BroadcasterMicroservice.Infrastructure.Implementations/"]
COPY ["BroadcasterMicroservice.Infrastructure.MongoDbContext/BroadcasterMicroservice.Infrastructure.MongoDbContext.csproj", "BroadcasterMicroservice.Infrastructure.MongoDbContext/"]
RUN dotnet restore "./Broadcaster/Broadcaster.csproj"
COPY . .
WORKDIR "/src/Broadcaster"
RUN dotnet build "./Broadcaster.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Этот этап используется для публикации проекта службы, который будет скопирован на последний этап
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Broadcaster.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Этот этап используется в рабочей среде или при запуске из VS в обычном режиме (по умолчанию, когда конфигурация отладки не используется)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Broadcaster.dll"]