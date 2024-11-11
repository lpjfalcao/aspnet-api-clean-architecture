# dotnet-api-task-manager
Projeto de REST API construída com .NET 6, com uso de Padrões de Projetos e Clean Architecture. 

## Pré-requisitos:

Antes de executar o projeto certifique-se de ter as configurações abaixo instaladas no seu ambiente.

+ .NET SDK 6
+ Visual Studio 2022
+ SQL Server rodando localmente no seu ambiente
+ Docker

## Rodando o projeto:

Siga os passos abaixo para rodar o projeto.

1. Abra o terminal do sistema operacional e clone este repositório utilizando o GIT para um diretório na sua máquina com o comando **git clone** https://github.com/lpjfalcao/dotnet-api-task-manager.git
2. Abra os arquivos appsettings.json e appsettings.development.json que estão na pasta TaskManager.WebApi do projeto clonado e configure o seu usuário e senha do SQL Server na string de conexão.
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

## Fase 2: Refinamento

- Quais informações sobre projeto devem ser armazenadas no sistema? Não ficou claro quais são os dados do projeto.
- Se não é necessário implementar autenticação/autorização nessa fase por que há uma regra para restringir os relatórios para usuários com função específica de "gerente"? 
- Sabemos que cada projeto deve ter uma prioridade atribuída, mas caso nenhuma prioridade seja informada qual deve ser definida por padrão? Como isso não foi especificado estamos definindo uma prioridade baixa por padrão caso nenhuma outra seja informada.
- Não ficou claro se na listagem de projetos devemos listar todos os projetos do sistema ou projetos de um usuário específico. Na modelagem atual e como foi sugerida pelos requisitos, o projeto não está associado a um usuário, mas sim a uma tarefa. Você acha interessante modelarmos o sistema de uma forma que o projeto esteja associado a um usuário ao invés de uma tarefa?
- Além da restrição de uso do relatório existe alguma outra restrição do que o usuário pode ou não fazer no sistema? Que tipos de usuário é esperado que tenhamos no sistema?
- O sistema que estamos desenvolvendo irá crescer em complexidade no futuro? O quão complexo ele será? É esperado ter muitas funcionalidades e muitos usuários usando o sistema? Consegue ter uma ideia de quantos usuários esperamos atender?

 ## Fase 3: Final

Como sugestão de melhoria para o projeto atual, precisava entender se o sistema irá crescer do ponto de vista de complexidade do negócio e de modelagem de dados. Caso o sistema se torne maior e mais complexo ao invés de adotar uma arquitetura monolítica poderíamos utilizar uma abordagem de microsserviços, onde teríamos o sistema segregado em diferentes serviços menores, cada um representando uma função isolada do negócio e que poderia ser publicada de forma independente, tornando mais fácil de escalar no futuro para atender as necessidades dos usuários. Isso também se aplicaria para a base de dados, onde cada serviço teria uma base de dados dedicada para seu uso pessoal e teríamos a flexibilidade para variar as tecnologias e selecionar as que mais se encaixem na nossa necessidade. 

Também seria interessante no futuro caso a complexidade do sistema aumente fazer o uso de uma solução de orquestração de container como o Amazon ECS ou Amazon EKS para gerenciar os microsserviços.  
  

