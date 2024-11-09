namespace TaskManager.Domain.Interfaces.Repositories
{
    public interface IRepositoryManager
    {
        ITarefaRepository Tarefa { get; }
        IProjetoRepository Projeto { get; }
        Task Commit();
    }
}
