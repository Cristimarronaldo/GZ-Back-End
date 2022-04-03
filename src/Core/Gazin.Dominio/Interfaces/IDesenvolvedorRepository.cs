using Gazin.Dominio.Models;

namespace Gazin.Dominio.Interfaces
{
    public interface IDesenvolvedorRepository : IRepository<Desenvolvedor>
    {
        Task<Desenvolvedor> ObterPorId(int id);
        Task<IEnumerable<Desenvolvedor>> ObterTodosDesenvolvedores();
        Task Adicionar(Desenvolvedor desenvolvedor);
        Task Atualizar(Desenvolvedor desenvolvedor);
        Task Excluir(int id);
    }
}
