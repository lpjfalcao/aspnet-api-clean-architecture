namespace TaskManager.Domain.Interfaces.Services
{
    public interface IProjetoService
    {
        Task ValidarSeProjetoTemTarefasPendentes(Guid projetoId);
    }
}
