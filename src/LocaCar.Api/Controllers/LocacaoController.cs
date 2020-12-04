using AutoMapper;
using LocaCar.Api.ViewModels;
using LocaCar.Business.Intefaces;
using LocaCar.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LocaCar.Api.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/locacao")]
    public class LocacaoController : BaseController
    {
        private readonly ILocacaoService _locacaoService;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public int MyProperty { get; set; }
        public LocacaoController(INotificador notificador,
                                 ILocacaoService clienteService,
                                 IMapper mapper,
                                 IClienteRepository clienteRepository) : base(notificador)
        {
            _locacaoService = clienteService;
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        [HttpPost]
        public async Task<ActionResult<LocacaoViewModel>> LocarVeiculo(LocacaoViewModel model)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var locacao = _mapper.Map<Locacao>(model);

            await _locacaoService.EfetuarLocacao(locacao, model.Cpf);

            model.ClientId = locacao.ClienteId;

            return CustomResponse(model);
        }
    }
}
