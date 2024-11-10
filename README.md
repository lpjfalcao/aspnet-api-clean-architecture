# dotnet-api-task-manager
Projeto de REST API construída com .NET 6, com uso de Padrões de Projetos e Clean Architecture. 

## Documentação da API:

https://localhost:7194/swagger/index.html

## Pré-requisitos:

Antes de executar o projeto certifique-se de ter as configurações abaixo instaladas no seu ambiente.

+ .NET SDK 6
+ Visual Studio 2022
+ SQL Server rodando localmente no seu ambiente
+ Docker

## Rodando o projeto:

Siga os passos abaixo para rodar o projeto.

1. Clone este repositório utilizando o GIT para um diretório na sua máquina: **git clone** https://github.com/lpjfalcao/dotnet-api-task-manager.git
2. Abra o terminal do sistema operacional e navegue até a pasta src do projeto clonado
3. Rode o comando "docker build -t task-manager ." para construir a imagem
4. Rode o comando "docker run --name task-manager-api -d -p 5000:80 -e ASPNETCORE_ENVIRONMENT=Development task-manager" 
5. Abra o navegador e acesse a documentação da API para ver se ela está online: http://localhost:5000/swagger/index.html

Obs.: Caso não queira usar o Swagger você pode usar um client como o Postman para fazer chamadas para testar a API.

## Configurando o ambiente:

O projeto usa o Entity Framework Core como solução de ORM. Siga os passos abaixo para criar o banco de dados:

1. Abra os arquivos appsettings.json e appsettings.development.json e configure o seu usuário e senha do SQL Server na string de conexão.
2. Abra o console do gerenciador de pacotes do nuget
3. Selecione o projeto TaskManager.Infra.Data 
4. Rode o comando "Add-Migration DatabaseCreation"
5. Rode o comando "Update-Database"
6. Ao final você deve ter um banco de dados configurado na sua instância do SQL Server em sua máquina com as tabelas usadas no projeto


## Testando o Projeto

Você pode utilizar a interface do Swagger para testar alguns endpoints: http://localhost:5000/swagger/index.html

