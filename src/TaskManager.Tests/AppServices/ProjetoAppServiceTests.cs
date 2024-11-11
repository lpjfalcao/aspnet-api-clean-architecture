using Moq;
using TaskManager.Application.Services;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Exceptions;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Domain.Interfaces.Services;

namespace TaskManager.Tests.AppServices
{
    public class ProjetoAppServiceTests
    {
        private readonly Mock<IRepositoryManager> _repositoryManagerMock;
        private readonly Mock<IProjetoService> _projetoServiceMock;
        private readonly ProjetoAppService _projetoAppService;

        public ProjetoAppServiceTests()
        {
            _repositoryManagerMock = new Mock<IRepositoryManager>();
            _projetoServiceMock = new Mock<IProjetoService>();
            _projetoAppService = new ProjetoAppService(_repositoryManagerMock.Object, _projetoServiceMock.Object);
        }

        [Fact]
        public async Task RemoverProjeto_ProjetoTemTarefasPendentes_DeveRetornarBadRequest()
        {
            // Arrange
            var projetoId = Guid.NewGuid();
            _projetoServiceMock.Setup(s => s.ValidarSeProjetoTemTarefasPendentes(projetoId))
                .Throws(new OperacaoNaoPermitidaException("Operação não permitida."));

            // Act
            var result = await _projetoAppService.RemoverProjeto(projetoId);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("Operação não permitida.", result.Message);
        }

        [Fact]
        public async Task RemoverProjeto_ProjetoValido_DeveRemoverProjeto()
        {
            // Arrange
            var projetoId = Guid.NewGuid();
            var projeto = new Projeto
            {
                Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                Nome = "Projeto Z"
            }; 
            _projetoServiceMock.Setup(s => s.ValidarSeProjetoTemTarefasPendentes(projetoId));
            _repositoryManagerMock.Setup(r => r.Projeto.ObterProjetoPorId(projetoId, false))
                .ReturnsAsync(projeto);

            // Act
            var result = await _projetoAppService.RemoverProjeto(projetoId);

            // Assert
            _repositoryManagerMock.Verify(r => r.Projeto.RemoverProjeto(projeto), Times.Once);
            Assert.True(result.Success);
        }
    }
}
