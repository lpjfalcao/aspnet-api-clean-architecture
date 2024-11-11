using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Enum;

namespace TaskManager.Infra.Data.Configurations
{
    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasData(
                new Tarefa
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    Titulo = "Cadastrar Usuários no Sistema",
                    DataVencimento = DateTime.Now.AddDays(5),
                    Descricao = "Essa é uma tarefa para realizar o cadastro de usuários no sistema",
                    ProjetoId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Status = TarefaStatusEnum.Pendente,
                    Prioridade = PrioridadeTarefaEnum.Media,
                    UsuarioId = new Guid("a69c1158-3c7e-4441-a3da-d060c2b5604c")
                },
                new Tarefa
                {
                    Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                    Titulo = "Criar uma nova Sprint para o Projeto",
                    DataVencimento = DateTime.Now.AddDays(10),
                    Descricao = "Essa é uma tarefa para criar uma nova sprint para o projeto",
                    ProjetoId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Status = TarefaStatusEnum.Concluido,
                    Prioridade = PrioridadeTarefaEnum.Baixa,
                    UsuarioId = new Guid("a69c1158-3c7e-4441-a3da-d060c2b5604c")
                },
                 new Tarefa
                 {
                     Id = new Guid("88696b49-5c8c-4927-a0a5-cc756e0df8b9"),
                     Titulo = "Criar uma nova Sprint para o Projeto",
                     DataVencimento = DateTime.Now.AddDays(10),
                     Descricao = "Essa é uma tarefa para criar uma nova sprint para o projeto",
                     ProjetoId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                     Status = TarefaStatusEnum.Concluido,
                     Prioridade = PrioridadeTarefaEnum.Baixa,
                     UsuarioId = new Guid("a69c1158-3c7e-4441-a3da-d060c2b5604c")
                 },
                  new Tarefa
                  {
                      Id = new Guid("88f32217-dfdf-4929-bf2d-0714d3178afa"),
                      Titulo = "Cadastrar Usuários no banco de dados",
                      DataVencimento = DateTime.Now.AddDays(10),
                      Descricao = "Essa é uma tarefa para cadastrar usuários no banco de dados",
                      ProjetoId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                      Status = TarefaStatusEnum.Concluido,
                      Prioridade = PrioridadeTarefaEnum.Baixa,
                      UsuarioId = new Guid("a69c1158-3c7e-4441-a3da-d060c2b5604c")
                  },
                new Tarefa
                {
                    Id = new Guid("a39740f1-2ad5-4a15-95b1-52bcb0530728"),
                    Titulo = "Migar o banco de dados SQL Server para o DynamoDB",
                    DataVencimento = DateTime.Now.AddDays(15),
                    Descricao = "Essa é uma tarefa para migrar o banco de dados",
                    ProjetoId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Status = TarefaStatusEnum.Andamento,
                    Prioridade = PrioridadeTarefaEnum.Alta,
                    UsuarioId = new Guid("0f58ef89-c87e-4c09-a9ad-4cbc2f764aec")
                },
                   new Tarefa
                   {
                       Id = new Guid("c75e6e5b-d81c-4cbd-b197-650abccc352b"),
                       Titulo = "Migar o banco de dados SQL Server para o DynamoDB",
                       DataVencimento = DateTime.Now.AddDays(15),
                       Descricao = "Essa é uma tarefa para migrar o banco de dados",
                       ProjetoId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                       Status = TarefaStatusEnum.Andamento,
                       Prioridade = PrioridadeTarefaEnum.Alta,
                       UsuarioId = new Guid("0f58ef89-c87e-4c09-a9ad-4cbc2f764aec")
                   }
            );
        }
    }
}
