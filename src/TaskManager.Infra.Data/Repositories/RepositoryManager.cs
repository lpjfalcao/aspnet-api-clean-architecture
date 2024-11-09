using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Infra.Data.Contextos;
using TaskManager.Infra.Data.Enums;
using TaskManager.Infra.Data.Factories;

namespace TaskManager.Infra.Data.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private ITarefaRepository tarefa;
        private IProjetoRepository projeto;

        private RepositoryContext contexto;

        public ITarefaRepository Tarefa
        {
            get
            {
                if (this.tarefa == null)
                    return RepositoryFactory.Create(RepositoryTypeEnum.Tarefa, contexto);

                return this.tarefa;
            }
        }

        public IProjetoRepository Projeto
        {
            get
            {
                if (projeto == null)
                    return RepositoryFactory.Create(RepositoryTypeEnum.Projeto, contexto);

                return this.projeto;
            }
        }

        public RepositoryManager(RepositoryContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task Commit()
        {
            await contexto.SaveChangesAsync();
        }
    }
}
