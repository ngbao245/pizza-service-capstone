# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy and restore
COPY ["src/Pizza4Ps.PizzaService.API/Pizza4Ps.PizzaService.API.csproj", "src/Pizza4Ps.PizzaService.API/"]
RUN dotnet restore "src/Pizza4Ps.PizzaService.API/Pizza4Ps.PizzaService.API.csproj"

# Copy the rest of the files and build
COPY . .
WORKDIR "src/Pizza4Ps.PizzaService.API"
RUN dotnet build "Pizza4Ps.PizzaService.API.csproj" -c Release -o /app/build

# Publish
RUN dotnet publish "Pizza4Ps.PizzaService.API.csproj" -c Release -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Set timezone to Vietnam
ENV TZ=Asia/Ho_Chi_Minh
RUN apt-get update && apt-get install -y tzdata && \
    ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Development
ENTRYPOINT ["dotnet", "Pizza4Ps.PizzaService.API.dll"]
