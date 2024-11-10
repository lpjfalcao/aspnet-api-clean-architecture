using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces.Repositories
{
    public interface IProjetoRepository
    {
        Task<Projeto> ObterProjetoPorId(Guid projetoId, bool trackChanges);
        Task<Projeto> ObterProjetoComTarefa(Guid projetoId);
        void RemoverProjeto(Projeto projeto);
    }
}
