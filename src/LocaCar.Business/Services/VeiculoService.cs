using System;
using System.Threading.Tasks;
using LocaCar.Business.Intefaces;
using LocaCar.Business.Models;
using LocaCar.Business.Models.Validations;

namespace LocaCar.Business.Services
{
    public class VeiculoService : BaseService, IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoService(IVeiculoRepository produtoRepository,
                              INotificador notificador) : base(notificador)
        {
            _veiculoRepository = produtoRepository;
        }

        public Task<bool> Adicionar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Atualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _veiculoRepository?.Dispose();
        }

        public Task<bool> Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}