FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PubSubDemo.DataProcessor/PubSubDemo.DataProcessor.csproj", "PubSubDemo.DataProcessor/"]
RUN dotnet restore "PubSubDemo.DataProcessor/PubSubDemo.DataProcessor.csproj"
COPY . .
WORKDIR "/src/PubSubDemo.DataProcessor"
RUN dotnet build "PubSubDemo.DataProcessor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PubSubDemo.DataProcessor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PubSubDemo.DataProcessor.dll"]