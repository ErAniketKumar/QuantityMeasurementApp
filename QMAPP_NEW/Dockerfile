# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Use existing user (UID 1000 exists in ASP.NET 10.0 image)
RUN chown -R 1000 /app
USER 1000

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "QMAPP.dll"]