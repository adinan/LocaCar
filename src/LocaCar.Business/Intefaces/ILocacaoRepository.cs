using LocaCar.Business.Models;
using System;
using System.Threading.Tasks;

namespace LocaCar.Business.Intefaces
{
    public interface ILocacaoRepository : IRepository<Locacao>
    {
        Task<Locacao> ObterPorData(DateTime dataInicio, DateTime dataFim)
    }
}
