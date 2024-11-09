using TaskManager.Infra.Data.Contextos;
using TaskManager.Infra.Data.Enums;
using TaskManager.Infra.Data.Repositories;

namespace TaskManager.Infra.Data.Factories
{
    public class RepositoryFactory
    {
        public static dynamic? Create(RepositoryTypeEnum tipo, RepositoryContext context)
        {
            return tipo switch
            {
                RepositoryTypeEnum.Tarefa => new TarefaRepository(context),
                RepositoryTypeEnum.Projeto => new ProjetoRepository(context),
                _=> null
            };
        }
    }
}
