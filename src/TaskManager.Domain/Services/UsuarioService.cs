using TaskManager.Domain.Exceptions;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Domain.Interfaces.Services;

namespace TaskManager.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public async Task<bool> ValidarSeUsuarioExiste(Guid id)
        {
            var usuario = await this.usuarioRepository.ObterUsuarioPorId(id);

            if (usuario is not null)
                return true;
            else
                throw new OperacaoNaoPermitidaException($"O usuário informado não está cadastrado no sistema: {id}");
        }
    }
}
