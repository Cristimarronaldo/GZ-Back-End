namespace Gazin.Dominio.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
