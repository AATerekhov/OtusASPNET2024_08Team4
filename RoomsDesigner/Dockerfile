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
COPY ["RoomsDesigner/RoomsDesigner.Api.csproj", "RoomsDesigner/"]
COPY ["RoomsDesigner.Application.Models/RoomsDesigner.Application.Models.csproj", "RoomsDesigner.Application.Models/"]
COPY ["RoomsDesigner.Application.Service.Abstractions/RoomsDesigner.Application.Service.Abstractions.csproj", "RoomsDesigner.Application.Service.Abstractions/"]
COPY ["RoomsDesigner.Application.Services.Implementations/RoomsDesigner.Application.Services.Implementations.csproj", "RoomsDesigner.Application.Services.Implementations/"]
COPY ["RoomsDesigner.Domain.Entity/RoomsDesigner.Domain.Entity.csproj", "RoomsDesigner.Domain.Entity/"]
COPY ["RoomsDesigner.Domain.Repository.Abstractions/RoomsDesigner.Domain.Repository.Abstractions.csproj", "RoomsDesigner.Domain.Repository.Abstractions/"]
COPY ["RoomsDesigner.Infrastructure.Repository.Implementations/RoomsDesigner.Infrastructure.Repository.Implementations.csproj", "RoomsDesigner.Infrastructure.Repository.Implementations/"]
COPY ["RoomsDesigner.Infrastructure.EntityFramework/RoomsDesigner.Infrastructure.EntityFramework.csproj", "RoomsDesigner.Infrastructure.EntityFramework/"]
RUN dotnet restore "./RoomsDesigner/RoomsDesigner.Api.csproj"
COPY . .
WORKDIR "/src/RoomsDesigner"
RUN dotnet build "./RoomsDesigner.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Этот этап используется для публикации проекта службы, который будет скопирован на последний этап
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RoomsDesigner.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Этот этап используется в рабочей среде или при запуске из VS в обычном режиме (по умолчанию, когда конфигурация отладки не используется)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RoomsDesigner.Api.dll"]