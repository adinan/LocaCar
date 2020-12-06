using LocaCar.Business.Models;
using System.Threading.Tasks;

namespace LocaCar.Business.Intefaces
{
    public interface IFipeApi 
    {
        Task<bool> ValidaInformacoesVeiculoTabelaFipe(Veiculo model);
    }
}
