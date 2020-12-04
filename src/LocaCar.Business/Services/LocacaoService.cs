using System;
using System.Threading.Tasks;
using LocaCar.Business.Intefaces;
using LocaCar.Business.Models;
using LocaCar.Business.Models.Validations;

namespace LocaCar.Business.Services
{
    public class LocacaoService : BaseService, ILocacaoService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ILocacaoRepository _locacaoRepository;
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly INotificador _notificador;

        public LocacaoService(IClienteRepository clienteRepository,
                              INotificador notificador,
                              IVeiculoRepository veiculoRepository,
                              ILocacaoRepository locacaoRepository) : base(notificador)
        {
            _clienteRepository = clienteRepository;
            _locacaoRepository = locacaoRepository;
            _veiculoRepository = veiculoRepository;
            _notificador = notificador;
        }

        public async Task EfetuarLocacao(Locacao locacao, string cpf)
        {
            //Validações
            await RetornaCliente(locacao, cpf);

            if (_veiculoRepository.ObterPorId(locacao.VeiculoId).Result == null)
                Notificar($"Veiculo não encontrado.");

            ExecutarValidacao(new LocacaoValidation(), locacao);

            if (_notificador.TemNotificacao())
                return;


            //Regra: O mesmo veículo não pode ser alocado caso já esteja reservado no período.
            foreach (var item in await _locacaoRepository.Buscar(l => l.Veiculo.Id == locacao.VeiculoId))
            {
                if (TemSobreposicaoDatas(locacao.DataInicio, locacao.DataFim, item.DataInicio, item.DataFim))
                {
                    Notificar($"Veiculo se encontra locado no período {item.DataInicio.ToShortDateString()} até {item.DataFim.ToShortDateString()}");
                    return;
                }
            }



            await _locacaoRepository.Adicionar(locacao);

        }

        private async Task RetornaCliente(Locacao locacao, string cpf)
        {
            var cliente = await _clienteRepository.ObterPorCpf(cpf);
            if (cliente == null)
            {
                cliente = new Cliente() { Cpf = cpf };
                if (ExecutarValidacao(new ClienteValidation(), cliente))
                    await _clienteRepository.Adicionar(cliente);
            }
            locacao.ClienteId = cliente.Id;
        }

        private bool TemSobreposicaoDatas(DateTime start1, DateTime end1, DateTime start2, DateTime end2)
        {
            return start1 < end2 && end1 > start2;
        }

        public void Dispose()
        {
            _clienteRepository?.Dispose();
            _locacaoRepository?.Dispose();
        }
    }
}