using System.Linq.Expressions;

namespace Gazin.Dominio.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate);
    }
}
