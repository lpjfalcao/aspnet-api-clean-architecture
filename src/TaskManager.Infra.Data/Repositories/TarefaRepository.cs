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

        public async Task<Tarefa> ObterTarefaPorId(Guid projetoId, Guid id, bool trackChanges)
        {
            return await GetByCondition(x => x.ProjetoId == projetoId && x.Id == id, trackChanges);
        }

        public void RemoverTarefa(Tarefa tarefa)
        {
            Remove(tarefa);
        }
    }
}
