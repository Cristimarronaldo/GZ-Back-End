using AutoMapper;
using Gazin.API.Controllers;
using Gazin.API.DTOs;
using Gazin.Dominio.Interfaces;
using Gazin.Dominio.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Gazin.API.V1.Controllers
{
       
    [Route("api/v1/niveis")]
    public class NiveisController : MainController
    {
        private readonly INiveisService _niveisService;
        private readonly INiveisRepository _niveisRepository;
        private readonly IMapper _mapper;
        public NiveisController(INiveisService niveisService,
                                INiveisRepository niveisRepository,
                                INotificador notificador,
                                IMapper mapper) : base(notificador)
        {
            _niveisService = niveisService;
            _niveisRepository = niveisRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<NiveisDTO>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<NiveisDTO>>(await _niveisRepository.ObterTodosNiveis());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<NiveisDTO>> ObterPorId(int id)
        {
            var niveisDTO = await ObterNiveis(id);

            if (niveisDTO == null) return NotFound();

            return niveisDTO;
        }

        [HttpPost]
        public async Task<ActionResult<NiveisDTO>> Adicionar(NiveisDTO niveisDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);   

            await _niveisService.Adicionar(_mapper.Map<Niveis>(niveisDTO));

            return CustomResponse(niveisDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<NiveisDTO>> Atualizar(int id, NiveisDTO niveisDTO)
        {
            if (id != niveisDTO.Id)
            {
                NotificarErro("O código informado não é o mesmo que foi passado na query");
                return CustomResponse(niveisDTO);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _niveisService.Atualizar(_mapper.Map<Niveis>(niveisDTO));

            return CustomResponse(niveisDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<NiveisDTO>> Excluir(int id)
        {
            var niveisDTO = await ObterNiveis(id);

            if (niveisDTO == null) return NotFound();

            await _niveisService.Excluir(id);

            return CustomResponse(niveisDTO);
        }

        private async Task<NiveisDTO> ObterNiveis(int id)
        {
            return _mapper.Map<NiveisDTO>(await _niveisRepository.ObterPorId(id));
        }
    }
}
