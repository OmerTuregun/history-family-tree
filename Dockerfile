# build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["SoyAgaci.Api/SoyAgaci.Api.csproj", "SoyAgaci.Api/"]
RUN dotnet restore "SoyAgaci.Api/SoyAgaci.Api.csproj"

COPY . .
RUN dotnet publish "SoyAgaci.Api/SoyAgaci.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
ENV ASPNETCORE_URLS=http://0.0.0.0:5010
EXPOSE 5010
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet","SoyAgaci.Api.dll"]
