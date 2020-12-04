using LocaCar.Business.Models;
using System.Threading.Tasks;

namespace LocaCar.Business.Intefaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> ObterPorCpf(string cpf);
    }
}
