using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Infra.Data.DataTransferObjects
{
    public class TarefaDto
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Status { get; set; }

        public Guid ProjetoId { get; set; }
    }
}
