FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000
# ENV DOTNET_ENVIRONMENT=Production esta no es la variable

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
#RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
#USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
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
#RUN dotnet tool install -g dotnet-ef --version 3.1.4 # .0.10

#RUN dotnet tool update --global dotnet-ef
#ENV export PATH='$PATH:/root/.dotnet/tools' >> ~/.bash_profile
#RUN dotnet add package Microsoft.EntityFrameworkCore.Design

#RUN export PATH="$PATH:/root/.dotnet/tools" >> .bashrc && dotnet ef
    #RUN dotnet ef migrations add DockerCreate --project 'Broidery.DataAccess.EntityFramework/Broidery.DataAccess.EntityFramework.csproj' --startup-project 'Broidery.Api.DockerStartup/Broidery.Api.DockerStartup.csproj' --verbose
#RUN cd Broidery.Api.DockerStartup && dotnet ef database update 

FROM build AS publish
RUN dotnet publish "Broidery.sln" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Broidery.Api.DockerStartup.dll"]