using System;
using System.Threading.Tasks;
using LocaCar.Business.Intefaces;
using LocaCar.Business.Models;
using LocaCar.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LocaCar.Data.Repository
{
    public class VeiculoRepository : Repository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(MeuDbContext context) : base(context) { }

        public async Task<Veiculo> ObterPorIdComLocacoes(Guid veiculoId)
        {
            return await Db.Veiculos.Include(l => l.Locacoes).AsNoTracking().FirstOrDefaultAsync(x => x.Id == veiculoId);
        }
    }
}