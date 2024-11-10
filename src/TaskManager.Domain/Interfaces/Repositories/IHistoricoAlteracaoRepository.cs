using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces.Repositories
{
    public interface IHistoricoAlteracaoRepository
    {
        void CriarHistorico(Guid tarefaId, HistoricoAlteracao historico);
    }
}
