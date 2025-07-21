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
    public class ArticulosStockRepository : IArticulosStockRepository
    {
        private readonly ApplicationDbContext _context;

        public ArticulosStockRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(ArticulosStock articulo) =>
            _context.ArticulosStocks.Add(articulo);

        public async Task<IEnumerable<ArticulosStock>> GetAll()
            => await _context.ArticulosStocks.ToListAsync();

        public async Task<ArticulosStock> GetById(long id) =>
           await _context.ArticulosStocks.Where(a => a.Id == (int)id).FirstOrDefaultAsync();

        public async Task<ArticulosStock> GetByIdShein(long id) => 
            await _context.ArticulosStocks.Where(a => a.IdShein == (int)id).FirstOrDefaultAsync();
    }
}
