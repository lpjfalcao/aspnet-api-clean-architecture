using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Domain.Entities
{
    public class HistoricoAlteracao
    {
        [Column("HistoricoAlteracaoId")]
        public Guid Id { get; set; }
        public string CampoAlterado { get; set; }
        public string Antes { get; set; }
        public string Depois { get; set; }
        public DateTime DataAlteracao { get; set; }

        public Guid TarefaId { get; set; }
        public Tarefa Tarefa { get; set; }
    }
}
