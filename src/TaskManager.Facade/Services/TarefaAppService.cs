using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Infra.Data.DataTransferObjects;
using TaskManager.Infra.Data.Helpers;

namespace TaskManager.Application.Services
{
    public class TarefaAppService : ITarefaAppService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly IMapper mapper;

        public TarefaAppService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            this.repositoryManager = repositoryManager;
            this.mapper = mapper;
        }

        public async Task<MessageHelper<TarefaDto>> CriarTarefa(Guid projetoId, TarefaCreationDto tarefaDto)
        {
            var message = new MessageHelper<TarefaDto>();

            try
            {
                var tarefa = this.mapper.Map<Tarefa>(tarefaDto);

                this.repositoryManager.Tarefa.CriarTarefaPorProjeto(projetoId, tarefa);
               
                await this.repositoryManager.Commit();

                message.Ok(this.mapper.Map<TarefaDto>(tarefa));
            }
            catch(Exception ex)
            {
                message.Error(ex);
            }

            return message;
        }
    }
}
