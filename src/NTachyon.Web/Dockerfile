FROM mcr.microsoft.com/dotnet/core/aspnet:2.2

RUN apt-get -qq update && \
    apt-get -qqy --no-install-recommends install \
    gnupg 

RUN curl -sL https://deb.nodesource.com/setup_6.x | bash -
RUN apt-get install -y nodejs

ARG source=./bin/Debug/netcoreapp2.2/publish/
WORKDIR /app
COPY $source .

EXPOSE 80
ENTRYPOINT ["dotnet", "NTachyon.Web.dll"]
