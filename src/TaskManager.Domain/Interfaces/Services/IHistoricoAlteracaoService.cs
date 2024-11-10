using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces.Services
{
    public interface IHistoricoAlteracaoService
    {
        Task<List<HistoricoAlteracao>> ObterHistoricoAlteracao(Guid projetoId, Tarefa tarefa);
    }
}
