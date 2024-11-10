namespace TaskManager.Infra.Data.DataTransferObjects
{
    public class TarefaCreationDto
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Prioridade { get; set; }
        public string Status { get; set; }
        public DateTime DataVencimento { get; set; }       
    }
}
