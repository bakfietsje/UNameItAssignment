FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["UNameItAssignment/UNameItAssignment.csproj", "UNameItAssignment/"]
RUN dotnet restore "UNameItAssignment/UNameItAssignment.csproj"

COPY UNameItAssignment/. UNameItAssignment/
COPY UNameItAssignment.sln .

WORKDIR /src/UNameItAssignment
RUN dotnet build "UNameItAssignment.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "UNameItAssignment.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UNameItAssignment.dll"]
