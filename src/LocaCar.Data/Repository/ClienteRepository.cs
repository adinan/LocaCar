using System.Threading.Tasks;
using LocaCar.Business.Intefaces;
using LocaCar.Business.Models;
using LocaCar.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LocaCar.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(MeuDbContext context) : base(context) { }

        public Task<Cliente> ObterPorCpf(string cpf)
        {
            return DbSet.AsNoTracking().FirstOrDefaultAsync(p => p.Cpf == cpf);
        }
    }
}