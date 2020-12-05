using LocaCar.Business.Models;
using System;
using System.Threading.Tasks;

namespace LocaCar.Business.Intefaces
{
    public interface ILocacaoService : IDisposable
    {
        Task EfetuarLocacao(Locacao locacao, string cpf);
    }
}
