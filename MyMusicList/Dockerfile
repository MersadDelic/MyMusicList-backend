FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MyMusicList/MyMusicList.csproj", "MyMusicList/"]
RUN dotnet restore "MyMusicList/MyMusicList.csproj"
COPY . .
WORKDIR "/src/MyMusicList"
RUN dotnet build "MyMusicList.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyMusicList.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyMusicList.dll"]
