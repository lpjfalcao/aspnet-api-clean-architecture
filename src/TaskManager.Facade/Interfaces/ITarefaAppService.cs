using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;
using TaskManager.Infra.Data.DataTransferObjects;
using TaskManager.Infra.Data.Helpers;

namespace TaskManager.Application.Interfaces
{
    public interface ITarefaAppService
    {
        Task<MessageHelper<TarefaDto>> CriarTarefa(Guid projetoId, TarefaCreationDto tarefaDto);
    }
}
