FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic AS base
WORKDIR /app
EXPOSE 5001 
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build
WORKDIR /src
COPY ["Broidery/Broidery.Api.DockerStartup/Broidery.Api.DockerStartup.csproj", "Broidery/Broidery.Api.DockerStartup/"]
RUN dotnet restore "Broidery/Broidery.Api.DockerStartup/Broidery.Api.DockerStartup.csproj"
COPY . .
WORKDIR "/src/Broidery/Broidery.Api.DockerStartup"
RUN dotnet build "Broidery.Api.DockerStartup.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Broidery.Api.DockerStartup.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_URLS http://*:5001
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Broidery.Api.DockerStartup.dll"]
