FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EgeBilgi_API/EgeBilgi_API.csproj", "EgeBilgi_API/"]
COPY ["EgeBilgi_Persistence/EgeBilgi_Persistence.csproj", "EgeBilgi_Persistence/"]
COPY ["EgeBilgi_Domain/EgeBilgi_Domain.csproj", "EgeBilgi_Domain/"]
COPY ["EgeBilgi_Infrastructure/EgeBilgi_Infrastructure.csproj", "EgeBilgi_Infrastructure/"]
COPY ["EgeBilgi_Application/EgeBilgi_Application.csproj", "EgeBilgi_Application/"]
COPY ["EgeBilgi_MediatR/EgeBilgi_MediatR.csproj", "EgeBilgi_MediatR/"]
RUN dotnet restore "EgeBilgi_API/EgeBilgi_API.csproj"
COPY . .
WORKDIR "/src/EgeBilgi_API"
RUN dotnet build "EgeBilgi_API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "EgeBilgi_API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EgeBilgi_API.dll"]
