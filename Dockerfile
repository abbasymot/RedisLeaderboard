FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./RedisLeaderboard.API/RedisLeaderboard.API.csproj"
RUN dotnet publish "./RedisLeaderboard.API/RedisLeaderboard.API.csproj" -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT [ "dotnet", "RedisLeaderboard.API.dll" ]
