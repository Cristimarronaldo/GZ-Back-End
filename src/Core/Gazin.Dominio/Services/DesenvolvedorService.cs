using Gazin.Dominio.Interfaces;
using Gazin.Dominio.Models;
using Gazin.Dominio.Validations;

namespace Gazin.Dominio.Services
{
    public class DesenvolvedorService : BaseService, IDesenvolvedorService
    {
        private readonly IDesenvolvedorRepository _desenvolvedorRepository;
        private readonly INiveisRepository _niveisRepository;
        public DesenvolvedorService(IDesenvolvedorRepository desenvolvedorRepository,
                                    INiveisRepository niveisRepository,
                                    INotificador notificador) : base(notificador)
        {
            _desenvolvedorRepository = desenvolvedorRepository;
            _niveisRepository = niveisRepository;
        }

        public async Task Adicionar(Desenvolvedor desenvolvedor)
        {
            desenvolvedor.AtualizarIdade(CalcularIdade(desenvolvedor.DataNascimento));
            var retornoValidacaoPadrao = ExecutarValidacao(new DesenvolvedorValidation(), desenvolvedor);

            var retornoValidacoes = await Validacoes(desenvolvedor.NivelId, desenvolvedor.Idade, desenvolvedor.Hobby);
            if (!retornoValidacoes || !retornoValidacaoPadrao) return;

            await _desenvolvedorRepository.Adicionar(desenvolvedor);
        }

        public async Task Atualizar(Desenvolvedor desenvolvedor)
        {
            desenvolvedor.AtualizarIdade(CalcularIdade(desenvolvedor.DataNascimento));

            var retornoValidacaoPadrao = ExecutarValidacao(new DesenvolvedorValidation(), desenvolvedor);

            var retornoValidacoes = await Validacoes(desenvolvedor.NivelId, desenvolvedor.Idade, desenvolvedor.Hobby);
            if (!retornoValidacoes || !retornoValidacaoPadrao) return;

            await _desenvolvedorRepository.Atualizar(desenvolvedor);
        }

        public async Task Excluir(int id)
        {
            if (_desenvolvedorRepository.ObterPorId(id).Result?.Id == 0)
            {
                Notificar("Não existe esse código para excluir!");
                return;
            }

            await _desenvolvedorRepository.Excluir(id);
        }

        public async Task<Desenvolvedor> ObterPorId(int id)
        {
            return await _desenvolvedorRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Desenvolvedor>> ObterTodosDesenvolvedores()
        {
            return await _desenvolvedorRepository.ObterTodosDesenvolvedores();
        }

        private async Task<bool> Validacoes(int niveId, int idade, string hobby)
        {
            var retorno = true;
            var nivel = await _niveisRepository.ObterPorId(niveId);
            if (nivel is null)
            {
                Notificar($"Não existe esse código {niveId} niveis cadastrado");
                retorno = false;                              
            }

            if (idade <= 17)           
            {
                Notificar($"A idade para ser desenvolvedor deve ser maior 17 anos");
                retorno = false;
            }

            if (hobby is not null && hobby.Length > 59)
            {
                Notificar($"Hobby precisar ter no máximo 60 caracteres.");
                retorno = false;
            }

            return retorno;
        }

        private int CalcularIdade(DateTime dataNascimento)
        {
            var idade = DateTime.Now.Year - dataNascimento.Year;
            if (idade > 0 && ((dataNascimento.Month > DateTime.Now.Month && dataNascimento.Year != DateTime.Now.Year) ||
                (dataNascimento.Month == DateTime.Now.Month && dataNascimento.Day > DateTime.Now.Day && dataNascimento.Year != DateTime.Now.Year)))
                idade--;
            idade = idade < 0 ? 0 : idade;
            return idade;
        }

        public void Dispose()
        {
            _desenvolvedorRepository?.Dispose();
        }
    }
}
