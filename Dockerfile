FROM mcr.microsoft.com/dotnet/sdk:8.0
AS build
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0
AS build
WORKDIR /src
COPY ["App Store.Api.csproj", "./"]
RUN dotnet restore "./App Store.Api.csproj"
COPY . .
RUN dotnet publish "./App Store.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
 ENTRYPOINT ["dotnet", "App Store.Api.dll"]
