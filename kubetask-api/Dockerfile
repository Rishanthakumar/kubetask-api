FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["kubetask-api/kubetask-api.csproj", "kubetask-api/"]
RUN dotnet restore "kubetask-api/kubetask-api.csproj"
COPY . .
WORKDIR "/src/kubetask-api"
RUN dotnet build "kubetask-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "kubetask-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "kubetask-api.dll"]