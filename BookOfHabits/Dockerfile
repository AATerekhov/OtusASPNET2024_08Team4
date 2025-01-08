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
COPY ["BookOfHabits/BookOfHabits.csproj", "BookOfHabits/"]
COPY ["BookOfHabitsMicroservice.Application.Services.Abstractions/BookOfHabitsMicroservice.Application.Services.Abstractions.csproj", "BookOfHabitsMicroservice.Application.Services.Abstractions/"]
COPY ["BookOfHabitsMicroservice.Application.Model/BookOfHabitsMicroservice.Application.Models.csproj", "BookOfHabitsMicroservice.Application.Model/"]
COPY ["BookOfHabitsMicroservice.Domain.Entity/BookOfHabitsMicroservice.Domain.Entity.csproj", "BookOfHabitsMicroservice.Domain.Entity/"]
COPY ["BookOfHabitsMicroservice.Domain.ValueObjects/BookOfHabitsMicroservice.Domain.ValueObjects.csproj", "BookOfHabitsMicroservice.Domain.ValueObjects/"]
COPY ["BookOfHabitsMicroservice.Application.Service/BookOfHabitsMicroservice.Application.Services.Implementations.csproj", "BookOfHabitsMicroservice.Application.Service/"]
COPY ["BookOfHabitsMicroservice.Application.Messages/BookOfHabitsMicroservice.Application.Messages.csproj", "BookOfHabitsMicroservice.Application.Messages/"]
COPY ["BookOfHabitsMicroservice.Domain.Repository.Abstractions/BookOfHabitsMicroservice.Domain.Repository.Abstractions.csproj", "BookOfHabitsMicroservice.Domain.Repository.Abstractions/"]
COPY ["BookOfHabitsMicroservice.Infrastructure.Repositories.Implementations/BookOfHabitsMicroservice.Infrastructure.Repositories.Implementations.csproj", "BookOfHabitsMicroservice.Infrastructure.Repositories.Implementations/"]
COPY ["BookOfHabitsMicroservice.Infrastructure.EntityFramework/BookOfHabitsMicroservice.Infrastructure.EntityFramework.csproj", "BookOfHabitsMicroservice.Infrastructure.EntityFramework/"]
RUN dotnet restore "./BookOfHabits/BookOfHabits.csproj"
COPY . .
WORKDIR "/src/BookOfHabits"
RUN dotnet build "./BookOfHabits.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Этот этап используется для публикации проекта службы, который будет скопирован на последний этап
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BookOfHabits.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Этот этап используется в рабочей среде или при запуске из VS в обычном режиме (по умолчанию, когда конфигурация отладки не используется)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookOfHabits.dll"]