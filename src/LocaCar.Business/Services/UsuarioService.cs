using System;
using System.Threading.Tasks;
using LocaCar.Business.Intefaces;
using LocaCar.Business.Models;

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

        public Task<bool> Adicionar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Atualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }
         
        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }

        public Task<bool> Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}