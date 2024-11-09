namespace TaskManager.Domain.Interfaces.Repositories
{
    public interface IRepositoryManager
    {
        ITarefaRepository Tarefa { get; }
        Task Commit();
    }
}
