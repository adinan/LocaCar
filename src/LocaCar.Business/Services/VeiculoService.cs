using System;
using System.Linq;
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

        public async Task Adicionar(Veiculo veiculo)
        {
            if (!ExecutarValidacao(new VeiculoValidation(), veiculo)) return;

            if (_veiculoRepository.Buscar(v => v.Placa == veiculo.Placa).Result.Any())
            {
                Notificar("Já existe um veículo com a placa informada");
                return;
            }
            
            await _veiculoRepository.Adicionar(veiculo);
        }

        public async Task Atualizar(Veiculo veiculo)
        {
            if (!ExecutarValidacao(new VeiculoValidation(), veiculo)) return;

            if (_veiculoRepository.ObterPorId(veiculo.Id).Result == null)
            {
                Notificar("Veiculo não encontrado.");
                return;
            }

            if (_veiculoRepository.Buscar(v => v.Placa == veiculo.Placa && v.Id != veiculo.Id).Result.Any())
            {
                Notificar("Já existe um veículo com a placa informada");
                return;
            }
            await _veiculoRepository.Atualizar(veiculo);
        }


        public async Task Remover(Guid id)
        {
            if (VeiculoEstaLocado(id))
            {
                Notificar("O veiculo está locado, não é possível excluir.");
                return;
            }
            //regra para locacoes futuras


            await _veiculoRepository.Remover(id);
        }

        private bool VeiculoEstaLocado(Guid id)
        {
            var locacoesVeiculo = _veiculoRepository.ObterPorId(id).Result.Locacoes;
            if (locacoesVeiculo == null) return false;

            return locacoesVeiculo.Any(locacao => locacao.DataInicio < DateTime.Now && DateTime.Now <= locacao.DataFim);
        }


        public void Dispose()
        {
            _veiculoRepository?.Dispose();

        }
    }
}