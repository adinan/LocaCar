using LocaCar.Business.Models;
using System;
using System.Threading.Tasks;

namespace LocaCar.Business.Intefaces
{
    public interface IVeiculoService : IDisposable
    {
        Task Adicionar(Veiculo usuario);
        Task Atualizar(Veiculo usuario);
        Task Remover(Guid id);
    }
}
