#!/bin/sh
dotnet restore
dotnet build
dotnet test
dotnet publish

docker build -t ntachyon.api:develop ./src/NTachyon.Api/.
docker build -t ntachyon.web:develop ./src/NTachyon.Web/.
docker tag ntachyon.api:develop falquan/ntachyon.api:alpha
docker tag ntachyon.web:develop falquan/ntachyon.web:alpha
docker push falquan/ntachyon.api:alpha
docker push falquan/ntachyon.web:alpha
