using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Infra.Data.DataTransferObjects;

namespace TaskManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private IAppServiceBase<Projeto, ProjetoDto> appService;

        public ProjetosController(IAppServiceBase<Projeto, ProjetoDto> appService)
        {
            this.appService = appService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dados = await this.appService.GetAll();

            return StatusCode(200, dados);
        }
    }
}
