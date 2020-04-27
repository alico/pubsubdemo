FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PubSubDemo.EventProcessor/PubSubDemo.EventProcessor.csproj", "PubSubDemo.EventProcessor/"]
RUN dotnet restore "PubSubDemo.EventProcessor/PubSubDemo.EventProcessor.csproj"
COPY . .
WORKDIR "/src/PubSubDemo.EventProcessor"
RUN dotnet build "PubSubDemo.EventProcessor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PubSubDemo.EventProcessor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PubSubDemo.EventProcessor.dll"]