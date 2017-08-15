FROM microsoft/aspnetcore:latest
ARG source=./bin/Debug/netcoreapp2.0/publish/
WORKDIR /app
COPY $source .

EXPOSE 80
ENTRYPOINT ["dotnet", "NTachyon.Api.dll"]
