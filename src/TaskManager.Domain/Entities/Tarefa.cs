using System.ComponentModel.DataAnnotations.Schema;
using TaskManager.Domain.Enum;

namespace TaskManager.Domain.Entities
{
    public class Tarefa
    {
        [Column("TarefaId")]
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public TarefaStatusEnum Status { get; set; }
        public PrioridadeTarefaEnum? Prioridade { get; set; }

        public Guid ProjetoId { get; set; }
        public Projeto Projeto { get; set; }
    }
}
