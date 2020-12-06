using LocaCar.Business.Models;
using System;
using System.Threading.Tasks;

namespace LocaCar.Business.Intefaces
{
    public interface IUsuarioService : IDisposable
    {
        Task Adicionar(Usuario usuario);
    }
}
