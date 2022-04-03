using Gazin.Dominio.Interfaces;
using Gazin.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Gazin.Infra.Data.Repository
{
    public class DesenvolvedorRepository : RepositoryBase,IDesenvolvedorRepository
    {
        private readonly GazinContext _context;

        protected readonly DbSet<Desenvolvedor> DbSet;

        public DesenvolvedorRepository(GazinContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Desenvolvedor desenvolvedor)
        {
            _context.Desenvolvedores.Add(desenvolvedor);
            await Salvar(_context);
        }

        public async Task Atualizar(Desenvolvedor desenvolvedor)
        {
            _context.Desenvolvedores.Update(desenvolvedor);
            await Salvar(_context);
        }

        public async Task<IEnumerable<Desenvolvedor>> Buscar(Expression<Func<Desenvolvedor, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }       

        public async Task Excluir(int id)
        {
            _context.Desenvolvedores.Remove(await ObterPorId(id));
            await Salvar(_context);
        }


        public async Task<Desenvolvedor> ObterPorId(int id)
        {
            return await _context.Desenvolvedores.FindAsync(id);
        }

        public async Task<IEnumerable<Desenvolvedor>> ObterTodosDesenvolvedores()
        {
            return await _context.Desenvolvedores.AsNoTracking().ToListAsync();
        }       

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
