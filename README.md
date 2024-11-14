# aspnet-api-clean-architecture

Este repositório contém um projeto de Web API Restful desenvolvida com o framework ASP .NET e está estruturado em camadas com uma arquitetura Clean, onde é feito o uso de Padrões de Projeto, como Unit of Work, Facade, Factory, Repository e Injeção de Dependência, para uma boa organização do código. 

Para o desenvolvimento dos endpoints foi utilizado um cenário de gerenciamento de tarefas em que há os recursos Projetos e Tarefas que são expostos pela API com operações de cadastro, atualização, exclusão e consulta. 

Na raiz do projeto existe um Dockerfile usado para dockerizar a aplicação e permitir que ela seja executada em um container do Docker. Abaixo seguem as instruções para configurar o ambiente e executar o projeto em sua máquina local.

## Pré-requisitos:

Antes de executar o projeto certifique-se de ter as configurações abaixo instaladas no seu ambiente.

+ .NET SDK 6 ou superior
+ Visual Studio 2022
+ SQL Server rodando localmente no seu ambiente
+ Docker
+ GIT

## Rodando o projeto:

Siga os passos abaixo para rodar o projeto.

1. Abra o terminal do sistema operacional e clone este repositório utilizando o GIT com o comando **git clone** https://github.com/lpjfalcao/aspnet-api-clean-architecture.git
2. Abra os arquivos appsettings.json e appsettings.development.json que estão na pasta src/TaskManager.WebApi do projeto clonado e configure o seu usuário e senha do SQL Server na string de conexão.
3. Navegue no terminal até a pasta src do projeto clonado
4. Rode o comando **docker build -t task-manager .** para construir a imagem do Docker
5. Rode o comando **docker run --name task-manager-api -d -p 5000:80 -e ASPNETCORE_ENVIRONMENT=Development task-manager** para executar a imagem em um container 
6. Abra o navegador e acesse a documentação da API para ver se ela está online em http://localhost:5000/swagger/index.html

## Configurando o ambiente:

O projeto usa o Entity Framework Core como solução de ORM para manipular e acessar dados. Siga os passos abaixo para criar o banco de dados:

1. Abra a solução no Visual Studio e vá até o console do gerenciador de pacotes do nuget
2. Selecione o projeto TaskManager.Infra.Data 
3. Rode o comando **Update-Database**
5. Ao final você deve ter um banco de dados configurado na sua instância do SQL Server em sua máquina com as tabelas usadas no projeto

Obs.: Para a conexão com o banco funcionar é necessário que seu SQL Server esteja configurado para permitir conexões de redes remotas e que no SQL Server Configuration Manager esteja com a opção TCP/IP habilitada.

## Testando o Projeto

Você pode utilizar a interface do Swagger para testar alguns endpoints: http://localhost:5000/swagger/index.html

1. **Listagem de Projetos** - endpoint: GET /api/projetos
2. **Visualização de Tarefas** - endpoint: GET /api/projetos/{projetoId}/tarefas
3. **Criação de Projetos** - endpoint: POST /api/projetos
4. **Criação de Tarefas** - endpoint: POST /api/projetos/{projetoId}/tarefas
5. **Atualização de Tarefas** - endpoint: PATCH /api/projetos/{projetoId}/tarefas/{id}
6. **Remoção de Tarefas** - endpoint: DELETE /api/projetos/{projetoId}/tarefas/{id}

Obs.: 
Existem outros endpoints além dos citados acima que você pode explorar na interface do Swagger.

  

