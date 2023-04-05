#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["VidlyNew/VidlyNew.csproj", "VidlyNew/"]
RUN dotnet restore "VidlyNew/VidlyNew.csproj"
COPY . .
WORKDIR "/src/VidlyNew"
RUN dotnet build "VidlyNew.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VidlyNew.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VidlyNew.dll"]