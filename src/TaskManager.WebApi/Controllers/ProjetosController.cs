using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Infra.Data.DataTransferObjects;

namespace TaskManager.WebApi.Controllers
{
    [Route("api/projetos")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private IAppServiceBase<Projeto> appService;

        public ProjetosController(IAppServiceBase<Projeto> appService)
        {
            this.appService = appService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterProjetos()
        {
            var message = await this.appService.GetAll<ProjetoDto>();

            return StatusCode(message.StatusCode, message);
        }

        [HttpGet("{id}", Name = "ObterProjetosPorId")]
        public async Task<IActionResult> ObterProjetosPorId(Guid id)
        {
            var message = await this.appService.GetByCondition<ProjetoDto>(x => x.Id == id);

            return StatusCode(message.StatusCode, message);
        }

        [HttpPost]
        public async Task<IActionResult> CriarProjeto(ProjetoCreationDto projetoDto)
        {
            var message = await this.appService.Add<ProjetoCreationDto>(projetoDto);

            return CreatedAtRoute("ObterProjetosPorId", new { message.Data.Id }, message.Data);
        }
    }
}
