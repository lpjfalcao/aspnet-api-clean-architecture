using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterUsuarioPorId(Guid id);
    }
}
