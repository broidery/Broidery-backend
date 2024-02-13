FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
#RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
#USER appuser

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Broidery.sln", "."]
COPY ["Broidery.Api/Broidery.Api.csproj", "Broidery.Api/"]
COPY ["Broidery.Api.Controllers/Broidery.Api.Controllers.csproj", "Broidery.Api.Controllers/"]
COPY ["Broidery.Api.DockerStartup/Broidery.Api.DockerStartup.csproj", "Broidery.Api.DockerStartup/"]
COPY ["Broidery.DataAccess/Broidery.DataAccess.csproj", "Broidery.DataAccess/"]
COPY ["Broidery.DataAccess.EntityFramework/Broidery.DataAccess.EntityFramework.csproj", "Broidery.DataAccess.EntityFramework/"]
COPY ["Broidery.DataTransferObjects/Broidery.DataTransferObjects.csproj", "Broidery.DataTransferObjects/"]
COPY ["Broidery.Interactors/Broidery.Interactors.csproj", "Broidery.Interactors/"]

RUN dotnet restore "Broidery.sln" 
COPY . .
RUN dotnet build "Broidery.sln" -c Release -o /app/build
#RUN dotnet tool install -g dotnet-ef

#RUN dotnet tool update --global dotnet-ef
#ENV export PATH='$PATH:/root/.dotnet/tools' >> ~/.bash_profile
#RUN dotnet add package Microsoft.EntityFrameworkCore.Design

#RUN export PATH="$PATH:/root/.dotnet/tools" && dotnet ef
#RUN export PATH="$PATH:/root/.dotnet/tools" && dotnet ef migrations add DockerCreate --project 'Broidery.DataAccess.EntityFramework/Broidery.DataAccess.EntityFramework.csproj' --startup-project 'Broidery.Api.DockerStartup/Broidery.Api.DockerStartup.csproj' --verbose
#RUN export PATH="$PATH:/root/.dotnet/tools" && cd Broidery.Api.DockerStartup && dotnet ef database update 

FROM build AS publish
RUN dotnet publish "Broidery.sln" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Broidery.Api.DockerStartup.dll"]
