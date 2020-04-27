FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PubSubDemo.ProductAPI/PubSubDemo.ProductAPI.csproj", "PubSubDemo.ProductAPI/"]
RUN dotnet restore "PubSubDemo.ProductAPI/PubSubDemo.ProductAPI.csproj"
COPY . .
WORKDIR "/src/PubSubDemo.ProductAPI"
RUN dotnet build "PubSubDemo.ProductAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PubSubDemo.ProductAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PubSubDemo.ProductAPI.dll"]