using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Exceptions;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Domain.Interfaces.Services;
using TaskManager.Infra.Data.Helpers;

namespace TaskManager.Application.Services
{
    public class ProjetoAppService : IProjetoAppService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly IProjetoService projetoService;

        public ProjetoAppService(IRepositoryManager repositoryManager, IProjetoService projetoService)
        {
            this.repositoryManager = repositoryManager;
            this.projetoService = projetoService;
        }
        
        public async Task<MessageHelper> RemoverProjeto(Guid projetoId)
        {
            var message = new MessageHelper();

            try
            {
                await this.projetoService.ValidarSeProjetoTemTarefasPendentes(projetoId);

                var projeto = await this.repositoryManager.Projeto.ObterProjetoPorId(projetoId, false);

                this.repositoryManager.Projeto.RemoverProjeto(projeto);

                await this.repositoryManager.Commit();

                message.Ok();
            }
            catch(OperacaoNaoPermitidaException ex)
            {
                message.BadRequest(ex);
            }
            catch(Exception ex)
            {
                message.Error(ex);
            }

            return message;
        }
    }
}
