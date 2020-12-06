using System;
using System.Collections.Generic;
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
        private readonly ILocacaoRepository _locacaoRepository;

        public VeiculoService(IVeiculoRepository produtoRepository,
                              INotificador notificador,
                              ILocacaoRepository locacaoRepository) : base(notificador)
        {
            _veiculoRepository = produtoRepository;
            _locacaoRepository = locacaoRepository;
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
            var locacaos = _locacaoRepository.ObterLocacoesVeiculo(id).Result.ToList();
            if (VeiculoEstaLocado(locacaos))
            {
                Notificar("O veiculo está locado, não é possível excluir.");
                return;
            }
            //regra para locacoes futuras

            _locacaoRepository.RemoverEmLote(locacaos);

            await _veiculoRepository.Remover(id);
        }

        private bool VeiculoEstaLocado(List<Locacao> locacoesVeiculo)
        {
            if (locacoesVeiculo == null) return false;
         
            return locacoesVeiculo.Any(l => l.DataInicio <= DateTime.Now && DateTime.Now <= l.DataFim);
        }


        public void Dispose()
        {
            _veiculoRepository?.Dispose();

        }
    }
}