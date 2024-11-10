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
    public class HistoricoAlteracaoRepository : RepositoryBase<HistoricoAlteracao>, IHistoricoAlteracaoRepository
    {
        public HistoricoAlteracaoRepository(RepositoryContext context) : base(context)
        {
            
        }
        public void CriarHistorico(Guid tarefaId, HistoricoAlteracao historico)
        {
            historico.TarefaId = tarefaId;
            Create(historico);
        }
    }
}
