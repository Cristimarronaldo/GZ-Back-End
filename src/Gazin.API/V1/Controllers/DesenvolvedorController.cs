using AutoMapper;
using Gazin.API.Controllers;
using Gazin.API.DTOs;
using Gazin.Dominio.Interfaces;
using Gazin.Dominio.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gazin.API.V1.Controllers
{
    [Route("api/v1/desenvolvedor")]
    public class DesenvolvedorController : MainController
    {
        private readonly IDesenvolvedorService _desenvolvedorService;
        private readonly IDesenvolvedorRepository _desenvolvedorRepository;
        private readonly INiveisRepository _niveisRepository;
        private readonly IMapper _mapper;

        public DesenvolvedorController(IDesenvolvedorService desenvolvedorService,
                                       IDesenvolvedorRepository desenvolvedorRepository,
                                       INiveisRepository niveisRepository,
                                       INotificador notificador,
                                       IMapper mapper) : base(notificador)
        {
            _desenvolvedorRepository = desenvolvedorRepository;
            _desenvolvedorService = desenvolvedorService;
            _niveisRepository = niveisRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<DesenvolvedorDTO>> ObterTodos()
        {
            var desenvolvedoresDTO = _mapper.Map<IEnumerable<DesenvolvedorDTO>>(await _desenvolvedorRepository.ObterTodosDesenvolvedores());
            return await ObterDesenvolvedoresNiveis(desenvolvedoresDTO);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DesenvolvedorDTO>> ObterPorId(int id)
        {
            var desenvolvedoresDTO = await ObterDesenvolvedor(id);

            if (desenvolvedoresDTO is null) return NotFound();

            return desenvolvedoresDTO;
        }

        [HttpPost]
        public async Task<ActionResult<DesenvolvedorDTO>> Adicionar(DesenvolvedorDTO desenvolvedorDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _desenvolvedorService.Adicionar(_mapper.Map<Desenvolvedor>(desenvolvedorDTO));

            return CustomResponse(desenvolvedorDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<DesenvolvedorDTO>> Atualizar(int id, DesenvolvedorDTO desenvolvedorDTO)
        {
            if (id != desenvolvedorDTO.Id)
            {
                NotificarErro("O código informado não é o mesmo que foi passado na query");
                return CustomResponse(desenvolvedorDTO);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _desenvolvedorService.Atualizar(_mapper.Map<Desenvolvedor>(desenvolvedorDTO));

            return CustomResponse(desenvolvedorDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<DesenvolvedorDTO>> Excluir(int id)
        {
            var desenvolvedorDTO = await ObterDesenvolvedor(id);

            if (desenvolvedorDTO == null) return NotFound();

            await _desenvolvedorService.Excluir(id);

            return CustomResponse(desenvolvedorDTO);
        }

        private async Task<DesenvolvedorDTO> ObterDesenvolvedor(int id)
        {
            var desenvolvedorDTO = _mapper.Map<DesenvolvedorDTO>(await _desenvolvedorRepository.ObterPorId(id));
            var nivelDTO = await _niveisRepository.ObterPorId(desenvolvedorDTO.NivelId);
            desenvolvedorDTO.Nivel = nivelDTO.Nivel;
            return desenvolvedorDTO;
        }

        private async Task<IEnumerable<DesenvolvedorDTO>> ObterDesenvolvedoresNiveis(IEnumerable<DesenvolvedorDTO> desenvolvedorDTO)
        {
            if (desenvolvedorDTO is not null)
            {
                var niveisDTO = _mapper.Map<IEnumerable<NiveisDTO>>(await _niveisRepository.ObterTodosNiveis());

                foreach (var desenvolvedor in desenvolvedorDTO)
                {                    
                    desenvolvedor.Nivel = niveisDTO.Where(n => n.Id == desenvolvedor.NivelId).FirstOrDefault().Nivel;
                }
            }
            return desenvolvedorDTO;
        }
    }
}
