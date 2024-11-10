namespace TaskManager.Domain.Interfaces.Repositories
{
    public interface IRepositoryManager
    {
        ITarefaRepository Tarefa { get; }
        IProjetoRepository Projeto { get; }
        IHistoricoAlteracaoRepository HistoricoAlteracao { get; }
        Task Commit();
    }
}
