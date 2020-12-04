using LocaCar.Business.Models;
using System;
using System.Threading.Tasks;

namespace LocaCar.Business.Intefaces
{
    public interface IVeiculoService : IDisposable
    {
        Task Adicionar(Veiculo veiculo);
        Task Atualizar(Veiculo veiculo);
        Task Remover(Guid id);
    }
}
