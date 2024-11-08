using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Domain.Entities
{
    public class Tarefa
    {
        [Column("TarefaId")]
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }

        public Guid ProjetoId { get; set; }
        public Projeto Projeto { get; set; }
    }
}
