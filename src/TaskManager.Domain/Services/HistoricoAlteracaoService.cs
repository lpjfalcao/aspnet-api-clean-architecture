using System.Reflection;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Domain.Interfaces.Services;

namespace TaskManager.Domain.Services
{
    public class HistoricoAlteracaoService : IHistoricoAlteracaoService
    {
        private readonly ITarefaRepository tarefaRepository;


        public HistoricoAlteracaoService(ITarefaRepository tarefaRepository)
        {
            this.tarefaRepository = tarefaRepository;
        }

        public async Task<List<HistoricoAlteracao>> ObterHistoricoAlteracao(Guid projetoId, Tarefa tarefa)
        {
            object? valorAntigo;
            object? valorNovo;

            var alteracoes = new List<HistoricoAlteracao>();

            var tarefaCadastrada = await this.tarefaRepository.ObterTarefaPorId(projetoId, tarefa.Id, false);

            MemberInfo[] fields = tarefaCadastrada.GetType().GetMembers();

            foreach (var field in fields)
            {
                if (field is PropertyInfo property)
                {
                    if (property.Name.Equals("Prioridade"))
                        continue;

                    valorAntigo = property.GetValue(tarefaCadastrada);
                    valorNovo = property.GetValue(tarefa);                    

                    if (!Equals(valorAntigo, valorNovo))
                        alteracoes.Add(new HistoricoAlteracao
                        {
                            CampoAlterado = field.Name,
                            Antes = valorAntigo.ToString(),
                            Depois = valorNovo.ToString(),
                            DataAlteracao = DateTime.Now
                        });
                }

            }

            return alteracoes;
        }
    }
}
