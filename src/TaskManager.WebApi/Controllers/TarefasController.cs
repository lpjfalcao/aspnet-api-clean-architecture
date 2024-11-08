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
        private IAppServiceBase<Tarefa, TarefaDto> appService;

        public TarefasController(IAppServiceBase<Tarefa, TarefaDto> appService)
        {
            this.appService = appService;                
        }

        [HttpGet]
        public async Task<IActionResult> ObterTarefasPorProjeto(Guid projetoId)
        {
            var dados = await this.appService.GetListByCondition(x => x.ProjetoId == projetoId);

            return StatusCode(200, dados);
        }
    }   
}
