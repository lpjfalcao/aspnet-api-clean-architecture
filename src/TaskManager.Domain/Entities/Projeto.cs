using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Domain.Entities
{
    public class Projeto
    {
        [Column("ProjetoId")]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Tarefa> Tarefa { get; set; }
    }
}
