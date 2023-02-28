FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ATM System/ATM System.csproj", "ATM System/"]
RUN dotnet restore "ATM System/ATM System.csproj"
COPY . .
WORKDIR "/src/ATM System"
RUN dotnet build "ATM System.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ATM System.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ATM System.dll"]
