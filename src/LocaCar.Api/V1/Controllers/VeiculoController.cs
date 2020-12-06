using AutoMapper;
using LocaCar.Api.Controllers;
using LocaCar.Api.ViewModels;
using LocaCar.Business.Intefaces;
using LocaCar.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocaCar.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/veiculos")]
    public class VeiculoController : BaseController
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IVeiculoService _veiculoService;
        private readonly IMapper _mapper;
        private readonly IFipeApi _fipeApi;

        public VeiculoController(INotificador notificador,
                                 IVeiculoRepository veiculoRepository,
                                 IMapper mapper,
                                 IVeiculoService veiculoService,
                                 IFipeApi fipeApi) : base(notificador)
        {
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
            _veiculoService = veiculoService;
            _fipeApi = fipeApi;
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<VeiculoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<VeiculoViewModel>>(await _veiculoRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<VeiculoViewModel>> ObterPorId(Guid id)
        {
            var veiculo = _mapper.Map<VeiculoViewModel>(await _veiculoRepository.ObterPorId(id));

            if (veiculo == null) return NotFound();

            return veiculo;
        }


        [HttpPost]
        public async Task<ActionResult<VeiculoViewModel>> Adicionar(VeiculoViewModel veiculoViewModel)
        {

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            veiculoViewModel.Id = Guid.NewGuid();
            var veiculo = _mapper.Map<Veiculo>(veiculoViewModel);

            if(!_fipeApi.ValidaInformacoesVeiculoTabelaFipe(veiculo).Result) return CustomResponse(ModelState);

            await _veiculoService.Adicionar(veiculo);

            veiculoViewModel.Id = veiculo.Id;
            return CustomResponse(veiculoViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<VeiculoViewModel>> Atualizar(Guid id, VeiculoViewModel veiculoViewModel)
        {
            if (id != veiculoViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(veiculoViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var veiculo = _mapper.Map<Veiculo>(veiculoViewModel);

            if (!_fipeApi.ValidaInformacoesVeiculoTabelaFipe(veiculo).Result) return CustomResponse(ModelState);

            await _veiculoService.Atualizar(veiculo);

            return CustomResponse(veiculoViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<VeiculoViewModel>> Excluir(Guid id)
        {
            var veiculoViewModel = _mapper.Map<VeiculoViewModel>(await _veiculoRepository.ObterPorId(id));

            if (veiculoViewModel == null) return NotFound();

            await _veiculoService.Remover(id);

            return CustomResponse(veiculoViewModel);
        }
    }
}
