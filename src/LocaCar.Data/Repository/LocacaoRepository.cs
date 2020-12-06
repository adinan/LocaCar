using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocaCar.Business.Intefaces;
using LocaCar.Business.Models;
using LocaCar.Data.Context;

namespace LocaCar.Data.Repository
{
    public class LocacaoRepository : Repository<Locacao>, ILocacaoRepository
    {
        public LocacaoRepository(MeuDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Locacao>> ObterLocacoesVeiculo(Guid veiculoId)
        {
            return await Buscar(l => l.VeiculoId == veiculoId);
        }

        public void RemoverEmLote(List<Locacao> listaLocacao)
        {
            DbSet.RemoveRange(listaLocacao);
        }
    }
}