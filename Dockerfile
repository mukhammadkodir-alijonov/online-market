FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY src/ .
WORKDIR /src/OnlineMarket.Web
RUN dotnet restore "OnlineMarket.Web.csproj"
RUN dotnet build "OnlineMarket.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OnlineMarket.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnlineMarket.Web.dll"]