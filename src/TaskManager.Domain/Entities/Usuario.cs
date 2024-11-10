using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Domain.Entities
{
    public class Usuario
    {
        [Column("UsuarioId")]
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Tarefa> Tarefas { get; set; }
    }
}
