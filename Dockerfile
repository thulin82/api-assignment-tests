FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY TodoApiTests/*.csproj ./TodoApiTests/
RUN dotnet restore

# copy everything else and build app
COPY TodoApiTests/. ./TodoApiTests/
WORKDIR /app/TodoApiTests
RUN dotnet publish -c Release -o out
WORKDIR /app/TodoApiTests/out
ENTRYPOINT ["dotnet", "vstest", "TodoApiTests.dll", "--logger:trx"]