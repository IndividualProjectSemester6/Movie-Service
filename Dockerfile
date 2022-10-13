# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
    
# Copy csproj and restore as distinct layers
#COPY *.sln .
COPY . .
#COPY /src/MoviesService.API/*.csproj .
#COPY /src/MoviesService.Application/*.csproj .
#COPY /src/MoviesService.Domain/*.csproj .
#COPY /src/MoviesService.Infrastructure/*.csproj .

#COPY *.csproj ./
RUN dotnet restore
    
# Copy everything else and build
#COPY . app/
#COPY /src/MoviesService.API/. /MoviesService.API/
#COPY /src/MoviesService.Application/. /MoviesService.Application/
#COPY /src/MoviesService.Domain/. /MoviesService.Domain/
#COPY /src/MoviesService.Infrastructure/. /MoviesService.Infrastructure/
RUN dotnet publish -c Release -o out
    
# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "MoviesService.API.dll"]