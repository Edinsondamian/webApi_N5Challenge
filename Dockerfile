# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /sln
COPY ["ChallengeN5.sln", "./"]
WORKDIR /sln/src
COPY ["src/API/ChallengeN5.API/ChallengeN5.API.csproj", "API/ChallengeN5.API/"]
COPY ["src/Core/ChallengeN5.Application/ChallengeN5.Application.csproj", "Core/ChallengeN5.Application/"]
COPY ["src/Core/ChallengeN5.Domain/ChallengeN5.Domain.csproj", "Core/ChallengeN5.Domain/"]
COPY ["src/Infra/ChallengeN5.Infrastructure.CrossCutting/ChallengeN5.Infrastructure.CrossCutting.csproj", "Infra/ChallengeN5.Infrastructure.CrossCutting/"]
COPY ["src/Infra/ChallengeN5.Infrastructure.Repository/ChallengeN5.Infrastructure.Repository.csproj", "Infra/ChallengeN5.Infrastructure.Repository/"]
COPY ["src/Infra/ChallengeN5.Infrastructure.KafkaProducer/ChallengeN5.Infrastructure.KafkaProducer.csproj", "Infra/ChallengeN5.Infrastructure.KafkaProducer/"]

WORKDIR /sln/test
COPY ["test/API/ChallengeN5.API.Test/ChallengeN5.API.Test.csproj", "API/ChallengeN5.API.Test/"]
COPY ["test/Core/ChallengeN5.Application.Test/ChallengeN5.Application.Test.csproj", "Core/ChallengeN5.Application.Test/"]
COPY ["test/Core/ChallengeN5.Domain.Test/ChallengeN5.Domain.Test.csproj", "Core/ChallengeN5.Domain.Test/"]
COPY ["test/Infra/ChallengeN5.Infrastructure.CrossCutting.Test/ChallengeN5.Infrastructure.CrossCutting.Test.csproj", "Infra/ChallengeN5.Infrastructure.CrossCutting.Test/"]
COPY ["test/Infra/ChallengeN5.Infrastructure.Repository.Test/ChallengeN5.Infrastructure.Repository.Test.csproj", "Infra/ChallengeN5.Infrastructure.Repository.Test/"]
WORKDIR /sln
RUN dotnet restore 
COPY . .

WORKDIR /sln/src/Core/ChallengeN5.Domain
RUN dotnet build -c Release -o /app/build

WORKDIR /sln/src/Infra/ChallengeN5.Infrastructure.Repository
RUN dotnet build -c Release -o /app/build

WORKDIR /sln/src/Infra/ChallengeN5.Infrastructure.CrossCutting
RUN dotnet build -c Release -o /app/build


WORKDIR /sln/src/Core/ChallengeN5.Application
RUN dotnet build -c Release -o /app/build

WORKDIR /sln/src/API/ChallengeN5.API

RUN dotnet build -c Release -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
WORKDIR "/sln/src/API/ChallengeN5.API"
ARG BUILD_CONFIGURATION=Release

RUN dotnet publish "./ChallengeN5.API.csproj" -c Release -o /app

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM base AS final
WORKDIR /app/build
COPY --from=publish /app .

EXPOSE 80 
ENTRYPOINT ["dotnet", "ChallengeN5.API.dll"]