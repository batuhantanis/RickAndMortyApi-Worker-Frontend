FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["egebilgi_worker.csproj", "egebilgi_worker/"]
RUN dotnet restore "egebilgi_worker/egebilgi_worker.csproj"

WORKDIR "/src/egebilgi_worker"
COPY . .

RUN dotnet build "egebilgi_worker.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "egebilgi_worker.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "egebilgi_worker.dll"]
