using System.ComponentModel;

namespace TaskManager.Domain.Enum
{
    public enum TarefaStatusEnum
    {
        [Description("Pendente")]
        Pendente,

        [Description("Andamento")]
        Andamento,

        [Description("Concluido")]
        Concluido
    }
}
