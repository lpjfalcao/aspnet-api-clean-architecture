using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Infra.Data.DataTransferObjects
{
    public class ProjetoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
