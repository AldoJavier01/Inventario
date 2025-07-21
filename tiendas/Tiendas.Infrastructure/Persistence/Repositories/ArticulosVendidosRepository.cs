using Fases.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendas.Domain.Aggregates;
using Tiendas.Domain.Repositories;

namespace Tiendas.Infrastructure.Persistence.Repositories
{
    public class ArticulosVendidosRepository : IArticulosVendidosRepository
    {
        private readonly ApplicationDbContext _context;

        public ArticulosVendidosRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(ArticulosVendidos articulo) =>
            _context.ArticulosVendidos.Add(articulo);

        public async Task<IEnumerable<ArticulosVendidos>> GetAll()
            => await _context.ArticulosVendidos.ToListAsync();

        public async Task<ArticulosVendidos> GetById(long id) =>
            await _context.ArticulosVendidos.Where(a => a.ArticuloId == (int)id).FirstOrDefaultAsync();
    }
}
