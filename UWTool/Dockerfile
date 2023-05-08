FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UWTool/UWTool.csproj", "UWTool/"]
RUN dotnet restore "UWTool/UWTool.csproj"
COPY . .
WORKDIR "/src/UWTool"
RUN dotnet build "UWTool.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UWTool.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UWTool.dll"]
