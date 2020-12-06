using LocaCar.Api.Extensions;
using LocaCar.Business.Intefaces;
using LocaCar.Business.Models;
using LocaCar.Business.Notificacoes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LocaCar.Api.Data
{

    public class FipeApi : IFipeApi
    {
        private readonly INotificador _notificador;
        public FipeApi(INotificador notificador)
        {
            _notificador = notificador;
        }

        public async Task<bool> ValidaInformacoesVeiculoTabelaFipe(Veiculo model)
        {
            using (var httpClient = new HttpClient())
            {
                var tipo = Enums.GetDescription((Enums.TipoVeiculo)model.TipoVeiculo);


                //Valida Marca
                string apiResponse = await httpClient.GetAsync($"http://fipeapi.appspot.com/api/1/{tipo}/marcas.json")
                    .Result.Content.ReadAsStringAsync();
                var marcaIdFipe = JsonConvert.DeserializeObject<List<VeiculosFipeResponse>>(apiResponse)
                    .FirstOrDefault(p => p.name.ToUpper() == model.Marca.ToUpper())?.id;

                if (marcaIdFipe == null)
                {
                    NotificarErro($"Marca '{model.Marca}' inexiste para o tipo de veiculo '{tipo}' na tabela FIPE");
                    return false;
                }

                //Valida Modelo
                apiResponse = await httpClient.GetAsync($"http://fipeapi.appspot.com/api/1/{tipo}/veiculos/{marcaIdFipe}.json")
                    .Result.Content.ReadAsStringAsync();
                var modelos = JsonConvert.DeserializeObject<List<VeiculosFipeResponse>>(apiResponse);

                if (!modelos.Any(p => p.name.ToUpper() == model.Modelo.ToUpper()))
                {
                    NotificarErro($"Modelo '{model.Modelo}' inexiste para a marca '{model.Marca}' na tabela FIPE");
                    return false;
                }
            }
            return true;
        }


        private void NotificarErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}
