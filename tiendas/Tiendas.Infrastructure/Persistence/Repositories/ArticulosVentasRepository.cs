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
    public class ArticulosVentasRepository : IArticulosVentasRepository
    {
        private readonly ApplicationDbContext _context;

        public ArticulosVentasRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(ArticulosVentas articulo) =>
            _context.ArticulosVentas.Add(articulo);

        public async Task<IEnumerable<ArticulosVentas>> GetAll()
            => await _context.ArticulosVentas.ToListAsync();

        public async Task<ArticulosVentas> GetById(long id) =>
            await _context.ArticulosVentas.Where(a => a.Id == (int)id).FirstOrDefaultAsync();
    }
}
