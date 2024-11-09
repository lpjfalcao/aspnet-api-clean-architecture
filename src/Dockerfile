# Usar a imagem base do SDK do .NET para compilar a aplicação
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copiar o arquivo de projeto e restaurar as dependências
COPY *.csproj ./
RUN dotnet restore

# Copiar o restante do código e compilar a aplicação
COPY . ./
RUN dotnet publish -c Release -o out

# Usar a imagem base do runtime do .NET para executar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out ./

# Definir a porta que a aplicação irá escutar
EXPOSE 80

# Comando para executar a aplicação
ENTRYPOINT ["dotnet", "TaskManager.WebApi.dll"]