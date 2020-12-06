using LocaCar.Business.Intefaces;
using LocaCar.Business.Models;
using LocaCar.Data.Context;

namespace LocaCar.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(MeuDbContext context) : base(context)
        {
        }
    }
}