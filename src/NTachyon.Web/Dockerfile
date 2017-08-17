FROM microsoft/aspnetcore:latest

RUN apt-get -qq update && apt-get -qqy --no-install-recommends install wget gnupg \
    git \
    unzip

RUN curl -sL https://deb.nodesource.com/setup_6.x | bash -
RUN apt-get install -y nodejs

ARG source=./bin/Debug/netcoreapp2.0/publish/
WORKDIR /app
COPY $source .

EXPOSE 80
ENTRYPOINT ["dotnet", "NTachyon.Web.dll"]
