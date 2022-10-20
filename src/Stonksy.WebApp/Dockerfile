FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Stonksy.WebApp/Stonksy.WebApp.csproj", "src/Stonksy.WebApp/"]
RUN dotnet restore "src/Stonksy.WebApp/Stonksy.WebApp.csproj"
COPY . .
WORKDIR "/src/src/Stonksy.WebApp"
RUN dotnet build "Stonksy.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Stonksy.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Stonksy.WebApp.dll"]
