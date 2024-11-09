using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Infra.Data.DataTransferObjects;


namespace TaskManager.WebApi.Controllers
{
    [Route("api/projetos/{projetoId}/tarefas")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private IAppServiceBase<Tarefa> appService;

        public TarefasController(IAppServiceBase<Tarefa> appService)
        {
            this.appService = appService;                
        }

        [HttpGet]
        public async Task<IActionResult> ObterTarefasPorProjeto(Guid projetoId)
        {
            var message = await this.appService.GetListByCondition<TarefaDto>(x => x.ProjetoId == projetoId);

            return StatusCode(message.StatusCode, message);
        }
    }   
}
