using System.Threading.Tasks;
using LocaCar.Business.Intefaces;
using LocaCar.Business.Models;
using LocaCar.Business.Models.Validations;

namespace LocaCar.Business.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository,
                              INotificador notificador) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task Adicionar(Usuario usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidation(), usuario)) return;

            //if (_usuarioRepository.Buscar(v => v.Nome == usuario.Nome).Result.Any())
            //{
            //    Notificar("Já usuário já cadastrado");
            //    return;
            //}

            await _usuarioRepository.Adicionar(usuario);
        }

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }
    }
}