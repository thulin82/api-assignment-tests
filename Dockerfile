FROM mcr.microsoft.com/dotnet/core/sdk:3.1

RUN apt-get update
RUN apt-get install sudo

RUN adduser --disabled-password --gecos '' docker
RUN adduser docker sudo
RUN echo '%sudo ALL=(ALL) NOPASSWD:ALL' >> /etc/sudoers

USER docker
WORKDIR /home/docker

# copy csproj and restore as distinct layers
COPY *.sln .
COPY TodoApiTests/*.csproj ./TodoApiTests/
RUN sudo chown -R docker:docker TodoApiTests
RUN sudo dotnet restore

# copy everything else and build app
COPY TodoApiTests/. ./TodoApiTests/
WORKDIR /home/docker/TodoApiTests
RUN sudo chmod -R 777 TestResults
RUN sudo dotnet publish -c Release -o out

ENV DOTNET_CLI_TELEMETRY_OPTOUT=1
ENV DOTNET_CLI_HOME="/tmp/DOTNET_CLI_HOME"