using AutoMapper;
using LocaCar.Api.ViewModels;
using LocaCar.Business.Intefaces;
using LocaCar.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocaCar.Api.Controllers
{
    [Route("api/veiculos")]
    public class VeiculoController : BaseController
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IVeiculoService _veiculoService;
        private readonly IMapper _mapper;

        public VeiculoController(INotificador notificador,
                                 IVeiculoRepository veiculoRepository,
                                 IMapper mapper, 
                                 IVeiculoService veiculoService) : base(notificador)
        {
            this._veiculoRepository = veiculoRepository;
            _mapper = mapper;
            _veiculoService = veiculoService;
        }


        [HttpGet]
        public async Task<IEnumerable<VeiculoViewModel>> ObterTodos()
        {
            var veiculos = _mapper.Map<IEnumerable<VeiculoViewModel>>(await _veiculoRepository.ObterTodos());

            return veiculos;
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
            if (!ModelState.IsValid) return BadRequest();

            var veiculo = _mapper.Map<Veiculo>(veiculoViewModel);
            await _veiculoService.Adicionar(veiculo);
             

            return Ok();
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

            await _veiculoService.Atualizar(_mapper.Map<Veiculo>(veiculoViewModel));

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
