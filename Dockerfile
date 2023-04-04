FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["eventsApi.csproj", "."]
RUN dotnet restore "./eventsApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "eventsApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eventsApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

RUN dotnet tool install --global dotnet-ef

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "eventsApi.dll" ]