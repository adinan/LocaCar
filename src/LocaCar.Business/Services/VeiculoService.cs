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

        public Task Adicionar(Veiculo usuario)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Veiculo usuario)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}