FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
ARG source=./bin/Debug/netcoreapp2.2/publish/
WORKDIR /app
COPY $source .

EXPOSE 80
ENTRYPOINT ["dotnet", "NTachyon.Api.dll"]
