using LocaCar.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocaCar.Business.Intefaces
{
    public interface ILocacaoRepository : IRepository<Locacao>
    {
        void RemoverEmLote(List<Locacao> listaLocacao);

        Task<IEnumerable<Locacao>> ObterLocacoesVeiculo(Guid veiculoId);
    }
}
