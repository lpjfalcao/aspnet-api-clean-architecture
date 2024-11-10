using TaskManager.Infra.Data.Helpers;

namespace TaskManager.Application.Interfaces
{
    public interface IProjetoAppService
    {
        public Task<MessageHelper> RemoverProjeto(Guid projetoId);
    }
}
