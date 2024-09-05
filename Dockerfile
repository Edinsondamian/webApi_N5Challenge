# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80 

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ChallengeN5.sln", "./"]
COPY ["src/API/ChallengeN5.API/ChallengeN5.API.csproj", "API/ChallengeN5.API/"]
COPY ["src/Core/ChallengeN5.Application/ChallengeN5.Application.csproj", "Core/ChallengeN5.Application/"]
COPY ["src/Core/ChallengeN5.Domain/ChallengeN5.Domain.csproj", "Core/ChallengeN5.Domain/"]
COPY ["src/Infra/ChallengeN5.Infrastructure.CrossCutting/ChallengeN5.Infrastructure.CrossCutting.csproj", "Infra/ChallengeN5.Infrastructure.CrossCutting/"]
COPY ["src/Infra/ChallengeN5.Infrastructure.Repository/ChallengeN5.Infrastructure.Repository.csproj", "Infra/ChallengeN5.Infrastructure.Repository/"]

COPY ["test/API/ChallengeN5.API.Test/ChallengeN5.API.Test.csproj", "API/ChallengeN5.API.Test/"]
COPY ["test/Core/ChallengeN5.Application.Test/ChallengeN5.Application.Test.csproj", "Core/ChallengeN5.Application.Test/"]
COPY ["test/Core/ChallengeN5.Domain.Test/ChallengeN5.Domain.Test.csproj", "Core/ChallengeN5.Domain.Test/"]
COPY ["test/Infra/ChallengeN5.Infrastructure.CrossCutting.Test/ChallengeN5.Infrastructure.CrossCutting.Test.csproj", "Infra/ChallengeN5.Infrastructure.CrossCutting.Test/"]
COPY ["test/Infra/ChallengeN5.Infrastructure.Repository.Test/ChallengeN5.Infrastructure.Repository.Test.csproj", "Infra/ChallengeN5.Infrastructure.Repository.Test/"]
RUN dotnet restore "/src/API/ChallengeN5.API/ChallengeN5.API.csproj"
COPY . .

WORKDIR /src/Core/ChallengeN5.Domain
RUN dotnet build -c Release -o /app/build

WORKDIR /src/Infra/ChallengeN5.Infrastructure.Repository
RUN dotnet build -c Release -o /app/build

WORKDIR /src/Infra/ChallengeN5.Infrastructure.CrossCutting
RUN dotnet build -c Release -o /app/build


WORKDIR /src/Core/ChallengeN5.Application
RUN dotnet build -c Release -o /app/build

WORKDIR /src/API/ChallengeN5.API
RUN ls
RUN dotnet build -c Release -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
WORKDIR "/src/API/ChallengeN5.API"
ARG BUILD_CONFIGURATION=Release
RUN ls
RUN dotnet publish "./ChallengeN5.API.csproj" -c Release -o /app

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM base AS final
WORKDIR /app/build
COPY --from=publish /app .
RUN ls
ENTRYPOINT ["dotnet", "ChallengeN5.API.dll"]