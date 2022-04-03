using Gazin.Dominio.Interfaces;
using Gazin.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Gazin.Infra.Data.Repository
{
    public class NiveisRepository : RepositoryBase,INiveisRepository
    {
        private readonly GazinContext _context;
        protected readonly DbSet<Niveis> DbSet;

        public NiveisRepository(GazinContext context)
        {
            _context = context;
            DbSet = _context.Set<Niveis>();
        }


        public async Task Adicionar(Niveis niveis)
        {
            _context.Niveis.Add(niveis);
            await Salvar(_context);
        }

        public async Task Atualizar(Niveis niveis)
        {
            _context.Niveis.Update(niveis);
            await Salvar(_context);
        }
        
        public async Task Excluir(int id)
        {
            _context.Niveis.Remove(await ObterPorId(id));
            await Salvar(_context);
        }

        public async Task<Niveis> ObterPorId(int id)
        {
            return await _context.Niveis.FindAsync(id);
        }

        public async Task<IEnumerable<Niveis>> ObterTodosNiveis()
        {
            return await _context.Niveis.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Niveis>> Buscar(Expression<Func<Niveis, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<Desenvolvedor> ObterDesenvolvedoresNiveis(int id)
        {
            return await _context.Desenvolvedores.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }        

        public void Dispose()
        {
            _context?.Dispose();
        }
        
    }
}
