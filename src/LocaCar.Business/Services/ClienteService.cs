using System;
using System.Threading.Tasks;
using LocaCar.Business.Intefaces;
using LocaCar.Business.Models;
using LocaCar.Business.Models.Validations;

namespace LocaCar.Business.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly  ILocacaoRepository _locacaoRepository;

        public ClienteService(IClienteRepository clienteRepository,
                              IVeiculoRepository veiculoRepository,
                              INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
            _veiculoRepository =  veiculoRepository;
        }

        public async Task EfetuarLocacao(Locacao locacao)
        {
             
            //● Regra: O mesmo veículo não pode ser alocado caso já esteja reservado no período.
            foreach (var item in locacao.Veiculo.Locacoes)
            {

                if (TemSobreposicaoDatas(locacao.DataInicio, locacao.DataFim, item.DataInicio, item.DataFim))
                    return;

                //if (locacao.DataInicio >= locacao.DataInicio && locacao.DataInicio < item.DataFim
                //    || locacao.DataFim > locacao.DataFim && locacao.DataFim <= item.DataInicio)
                //    return;
            }

            await _locacaoRepository.Adicionar(locacao);
             
        }
        /*
         SELECT * FROM table
          WHERE ((DATA1 >= DI) and (DATA1 <= DF)) OR
          ((DATA2 >= DI) and (DATA2 <= DF)) OR
          ((DATA1 <= DI) and (DATA2 >= DF))
         
         */

        private bool TemSobreposicaoDatas(DateTime start1, DateTime end1, DateTime start2, DateTime end2)
        {
            return start1 < end2 && end1 > start2;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}