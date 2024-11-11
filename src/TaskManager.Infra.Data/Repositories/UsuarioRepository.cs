using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Infra.Data.Contextos;

namespace TaskManager.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(RepositoryContext context) : base(context)
        {
            
        }

        public async Task<Usuario> ObterUsuarioPorId(Guid id)
        {
            return await GetByCondition(x => x.Id == id);
        }
    }
}
