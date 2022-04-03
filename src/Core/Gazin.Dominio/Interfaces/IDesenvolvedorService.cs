using Gazin.Dominio.Models;

namespace Gazin.Dominio.Interfaces
{
    public interface IDesenvolvedorService : IDisposable
    {
        Task<Desenvolvedor> ObterPorId(int id);
        Task<IEnumerable<Desenvolvedor>> ObterTodosDesenvolvedores();
        Task Adicionar(Desenvolvedor desenvolvedor);
        Task Atualizar(Desenvolvedor desenvolvedor);
        Task Excluir(int id);
    }
}
