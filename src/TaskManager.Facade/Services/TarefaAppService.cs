using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Exceptions;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Domain.Interfaces.Services;
using TaskManager.Infra.Data.DataTransferObjects;
using TaskManager.Infra.Data.Helpers;

namespace TaskManager.Application.Services
{
    public class TarefaAppService : ITarefaAppService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly ITarefaService tarefaService;
        private readonly IHistoricoAlteracaoService historicoAlteracaoService;
        private readonly IMapper mapper;

        public TarefaAppService(IRepositoryManager repositoryManager, ITarefaService tarefaService, IHistoricoAlteracaoService historicoAlteracaoService, IMapper mapper)
        {
            this.repositoryManager = repositoryManager;
            this.tarefaService = tarefaService;
            this.historicoAlteracaoService = historicoAlteracaoService;
            this.mapper = mapper;
        }

        public async Task<MessageHelper<TarefaDto>> CriarTarefa(Guid projetoId, TarefaCreationDto tarefaDto)
        {
            var message = new MessageHelper<TarefaDto>();

            try
            {
                var tarefa = this.mapper.Map<Tarefa>(tarefaDto);

                this.tarefaService.ConfigurarPrioriedade(tarefa);

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

        public async Task<MessageHelper> AtualizarCamposTarefa(Guid projetoId, Guid id, JsonPatchDocument<TarefaDto> patchDoc)
        {
            var message = new MessageHelper();

            try
            {
                var projeto = await this.repositoryManager.Projeto.ObterProjetoPorId(projetoId, false) ?? throw new Exception("O projeto não foi encontrado");
                var tarefa = await this.repositoryManager.Tarefa.ObterTarefaPorId(projetoId, id, true) ?? throw new Exception("A tarefa não foi encontrada");
               
                if (patchDoc.Operations.Where(x => x.path.Contains("prioridade")).Any())
                    this.tarefaService.ValidarPrioriedade(tarefa);

                var tarefaToPatch = this.mapper.Map<TarefaDto>(tarefa);

                patchDoc.ApplyTo(tarefaToPatch);

                this.mapper.Map(tarefaToPatch, tarefa);

                var historicoAlteracoes = await this.historicoAlteracaoService.ObterHistoricoAlteracao(projetoId, tarefa);

                foreach (var historicoAlteracao in historicoAlteracoes)
                {
                    this.repositoryManager.HistoricoAlteracao.CriarHistorico(id, historicoAlteracao);
                }                

                await this.repositoryManager.Commit();

                message.Ok();
            }
            catch (OperacaoNaoPermitidaException ex)
            {
                message.BadRequest(ex);
            }
            catch (Exception ex)
            {
                message.Error(ex);
            }

            return message;
        }

        public async Task<MessageHelper> RemoverTarefaPorProjeto(Guid projetoId, Guid id)
        {
            var message = new MessageHelper();

            try
            {
                var projeto = await this.repositoryManager.Projeto.ObterProjetoPorId(projetoId, false);

                if (projeto == null)
                    throw new Exception("O projeto não foi encontrado");

                var tarefa = await this.repositoryManager.Tarefa.ObterTarefaPorId(projetoId, id, false);

                if (tarefa == null)
                    throw new Exception("A tarefa não foi encontrada");

                this.repositoryManager.Tarefa.RemoverTarefa(tarefa);

                await this.repositoryManager.Commit();

                message.Ok();
            }           
            catch (Exception ex)
            {
                message.Error(ex);
            }

            return message;
        }
    }
}
