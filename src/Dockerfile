FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build-env
WORKDIR /App

ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /App
COPY --from=build-env /App/out ./
ENTRYPOINT ["dotnet", "TaskManager.WebApi.dll"]