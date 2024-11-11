using Microsoft.AspNetCore.JsonPatch;
using TaskManager.Infra.Data.DataTransferObjects;
using TaskManager.Infra.Data.Helpers;

namespace TaskManager.Application.Interfaces
{
    public interface ITarefaAppService
    {
        Task<MessageHelper<TarefaDto>> CriarTarefa(Guid projetoId, Guid usuarioId, TarefaCreationDto tarefaDto);
        Task<MessageHelper> AtualizarCamposTarefa(Guid projetoId, Guid id, JsonPatchDocument<TarefaUpdateDto> patchDoc);
        Task<MessageHelper> RemoverTarefaPorProjeto(Guid projetoId, Guid id);
        Task<MessageHelper<Dictionary<Guid, double>>> ObterMediaTarefasConcluidasPorUsuario(Guid usuarioId);
    }
}
