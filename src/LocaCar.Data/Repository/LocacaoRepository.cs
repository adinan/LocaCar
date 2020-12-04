using System;
using System.Threading.Tasks;
using LocaCar.Business.Intefaces;
using LocaCar.Business.Models;
using LocaCar.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LocaCar.Data.Repository
{
    public class LocacaoRepository : Repository<Locacao>, ILocacaoRepository
    {
        public LocacaoRepository(MeuDbContext context) : base(context)
        {
        }
    }
}