using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Infra.Data.Contextos;

namespace TaskManager.Infra.Data.Repositories
{
    public class ProjetoRepository : RepositoryBase<Projeto>, IProjetoRepository
    {
        public ProjetoRepository(RepositoryContext context) : base(context)
        {
            
        }
        public async Task<Projeto> ObterProjetoPorId(Guid projetoId, bool trackChanges)
        {
            return await GetByCondition(x => x.Id == projetoId);
        }
    }
}
