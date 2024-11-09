using Azure;
using Microsoft.AspNetCore.JsonPatch;
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
        private readonly IAppServiceBase<Tarefa> appService;
        private readonly ITarefaAppService tarefaAppService;

        public TarefasController(IAppServiceBase<Tarefa> appService, ITarefaAppService tarefaAppService)
        {
            this.appService = appService;
            this.tarefaAppService = tarefaAppService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTarefasPorProjeto(Guid projetoId)
        {
            var message = await this.appService.GetListByCondition<TarefaDto>(x => x.ProjetoId == projetoId);

            return StatusCode(message.StatusCode, message);
        }

        [HttpGet("{id}", Name = "ObterTarefasPorId")]
        public async Task<IActionResult> ObterTarefasPorId(Guid projetoId, Guid id)
        {
            var message = await this.appService.GetByCondition<TarefaDto>(x => x.Id == id && x.ProjetoId == projetoId);

            return StatusCode(message.StatusCode, message);
        }

        [HttpPost]
        public async Task<IActionResult> CriarTarefaPorProjeto(Guid projetoId, TarefaCreationDto tarefaDto)
        {
            var message = await this.tarefaAppService.CriarTarefa(projetoId, tarefaDto);

            return CreatedAtRoute("ObterTarefasPorId", new { Id = message.Data.Id, ProjetoId = projetoId  }, message.Data);

        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> AtualizarCamposTarefa(Guid projetoId, Guid id, [FromBody] JsonPatchDocument<TarefaDto> patchDoc)
        {
            var message = await this.tarefaAppService.AtualizarCamposTarefa(projetoId, id, patchDoc);

            return StatusCode(message.StatusCode, message);
        }
    }   
}
