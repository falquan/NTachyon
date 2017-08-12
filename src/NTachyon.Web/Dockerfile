FROM microsoft/aspnetcore:latest
ARG source=./bin/Debug/netcoreapp1.1/
WORKDIR /app
COPY $source .

EXPOSE 80
ENTRYPOINT ["dotnet", "NTachyon.Web.dll"]
