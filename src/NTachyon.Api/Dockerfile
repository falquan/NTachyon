FROM microsoft/aspnetcore:latest
ARG source
WORKDIR /app
EXPOSE 80
COPY ${source:-bin/Release/PublishOutput} .
ENTRYPOINT ["dotnet", "NTachyon.Api.dll"]
