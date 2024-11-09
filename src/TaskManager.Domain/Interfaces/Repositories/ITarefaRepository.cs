using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces.Repositories
{
    public interface ITarefaRepository
    {
        void CriarTarefaPorProjeto(Guid projetoId, Tarefa tarefa);
        Task<Tarefa> ObterTarefaPorId(Guid projetoId, Guid id, bool trackChanges);
        void RemoverTarefa(Tarefa tarefa);
    }
}
