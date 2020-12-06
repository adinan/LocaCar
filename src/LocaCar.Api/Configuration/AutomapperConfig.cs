using AutoMapper;
using LocaCar.Api.ViewModels;
using LocaCar.Business.Models;

namespace LocaCar.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Veiculo, VeiculoViewModel>().ReverseMap();

            CreateMap<Locacao, LocacaoViewModel>().ReverseMap();

            //CreateMap<LocacaoViewModel, Locacao>()
            //    .ConstructUsing(m => new Locacao(Guid.Empty, m.VeiculoId, m.DataInicio, m.DataFim));

        }
    }
}
