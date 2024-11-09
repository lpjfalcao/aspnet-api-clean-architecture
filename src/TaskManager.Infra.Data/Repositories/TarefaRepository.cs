using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Infra.Data.Contextos;

namespace TaskManager.Infra.Data.Repositories
{
    public class TarefaRepository : RepositoryBase<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(RepositoryContext context) : base(context)
        {
            
        }

        public void CriarTarefaPorProjeto(Guid projetoId, Tarefa tarefa)
        {
            tarefa.ProjetoId = projetoId;
            Create(tarefa);
        }
    }
}
