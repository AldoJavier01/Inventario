using Fases.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Tiendas.Domain.Aggregates;
using Tiendas.Domain.Repositories;

namespace Tiendas.Infrastructure.Persistence.Repositories
{
    public class TiendasFisicasRepository : ITiendaRepository
    {
        private readonly ApplicationDbContext _context;

        public TiendasFisicasRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(TiendasFisicas articulo) =>
            _context.TiendasFisicas.Add(articulo);

        public async Task<IEnumerable<TiendasFisicas>> GetAll()
            => await _context.TiendasFisicas.ToListAsync();

        public async Task<TiendasFisicas> GetById(long id) =>
            await _context.TiendasFisicas.Where(a => a.Id == (int)id).FirstOrDefaultAsync();
    }
}
