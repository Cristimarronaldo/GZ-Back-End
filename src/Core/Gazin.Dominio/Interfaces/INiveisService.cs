using Gazin.Dominio.Models;

namespace Gazin.Dominio.Interfaces
{
    public interface INiveisService : IDisposable
    {
        Task<Niveis> ObterPorId(int id);
        Task<IEnumerable<Niveis>> ObterTodosNiveis();
        Task Adicionar(Niveis niveis);
        Task Atualizar(Niveis niveis);
        Task Excluir(int id);
    }
}
