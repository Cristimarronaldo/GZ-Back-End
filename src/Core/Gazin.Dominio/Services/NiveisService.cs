using Gazin.Dominio.Interfaces;
using Gazin.Dominio.Models;
using Gazin.Dominio.Validations;

namespace Gazin.Dominio.Services
{
    public class NiveisService : BaseService, INiveisService
    {
        private readonly INiveisRepository _niveisRepository;

        public NiveisService(INiveisRepository niveisRepository,
                             INotificador notificador) : base(notificador)
        {
            _niveisRepository = niveisRepository;
        }
        public async Task Adicionar(Niveis niveis)
        {
            if (!ExecutarValidacao(new NiveisValidation(), niveis)) return;

            if (_niveisRepository.Buscar(n => n.Nivel == niveis.Nivel && n.Id != niveis.Id).Result.Any())
            {
                Notificar("Já existe este Nivel.");
                return;
            }

            await _niveisRepository.Adicionar(niveis);
        }

        public async Task Atualizar(Niveis niveis)
        {
            if (!ExecutarValidacao(new NiveisValidation(), niveis)) return;

            if (_niveisRepository.Buscar(n => n.Nivel == niveis.Nivel && n.Id != niveis.Id).Result.Any())
            {
                Notificar("Já existe este Nivel.");
                return;
            }

            await _niveisRepository.Atualizar(niveis);
        }        

        public async Task Excluir(int id)
        {
            if (_niveisRepository.ObterDesenvolvedoresNiveis(id).Result?.Id > 0)
            {
                Notificar("O nível possui(em) desenvolvedor(es) vinculado(s), não será possível excluir!");
                return;
            }            

            await _niveisRepository.Excluir(id);
        }

        public async Task<Niveis> ObterPorId(int id)
        {
            return await _niveisRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Niveis>> ObterTodosNiveis()
        {
            return await _niveisRepository.ObterTodosNiveis();
        }
        
       
        public void Dispose()
        {
            _niveisRepository?.Dispose();
        }
       
    }
}
