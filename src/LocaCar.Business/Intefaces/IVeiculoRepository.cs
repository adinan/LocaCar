using LocaCar.Business.Models;
using System;
using System.Threading.Tasks;

namespace LocaCar.Business.Intefaces
{
    public interface IVeiculoRepository : IRepository<Veiculo>
    {
        Task<Veiculo> ObterPorIdComLocacoes(Guid id);
    }
}
