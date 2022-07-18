FROM mcr.microsoft.com/dotnet/sdk:6.0 as BUILD
WORKDIR /source

COPY . ./
RUN rm appsettings.json
RUN mv appsettings.Docker.json appsettings.json

RUN dotnet restore

RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=BUILD /app ./
ENTRYPOINT [ "dotnet", "ClippingWorker.dll"]