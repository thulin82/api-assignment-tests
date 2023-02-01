FROM mcr.microsoft.com/dotnet/core/sdk:2.2

WORKDIR /tmp

# copy csproj and restore as distinct layers
COPY *.sln .
COPY TodoApiTests/*.csproj ./TodoApiTests/
RUN dotnet restore

# copy everything else and build app
COPY TodoApiTests/. ./TodoApiTests/
WORKDIR /tmp/TodoApiTests
RUN dotnet publish -c Release -o out
WORKDIR /tmp/TodoApiTests/out

ENV DOTNET_CLI_TELEMETRY_OPTOUT=1
ENV DOTNET_CLI_HOME="/tmp/DOTNET_CLI_HOME"