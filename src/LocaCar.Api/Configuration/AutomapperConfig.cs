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
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
             
        }
    }
}
