using TaskManager.Domain.Entities;
using TaskManager.Domain.Enum;
using TaskManager.Domain.Exceptions;
using TaskManager.Domain.Interfaces.Services;

namespace TaskManager.Domain.Services
{
    public class TarefaService : ITarefaService
    {
        public TarefaService()
        {
        }

        public void ConfigurarPrioriedade(Tarefa tarefa)
        {
            tarefa.Prioridade ??= PrioridadeTarefaEnum.Baixa;
        }

        public void ValidarPrioriedade(Tarefa tarefa)
        {
            if (tarefa.Prioridade is not null)             
                throw new OperacaoNaoPermitidaException("Não é permitido alterar a prioridade de uma tarefa depois que ela foi criada");
        }
    }
}
