using Fases.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
            => from venta in _context.ArticulosVentas
               join articulo in _context.ArticulosStocks on venta.IdArticulo equals articulo.Id
              
               select new ArticulosVentas(venta.Id, venta.IdTienda, venta.IdArticulo, venta.PrecioVenta, articulo.SKU, venta.Talla, venta.Cantidad);


        public void Delete(ArticulosVentas articulo)
        {
            _context.Remove(articulo);
        }
        public async Task<ArticulosVentas> GetById(long id) =>
            await _context.ArticulosVentas.Where(a => a.Id == (int)id).FirstOrDefaultAsync();

        public async Task<IEnumerable<ArticulosVentas>> ObtenerPorCodigo (long cod)
        {
            var test = (from venta in _context.ArticulosVentas
                        join articulo in _context.ArticulosStocks on venta.IdArticulo equals articulo.Id
                        select new { venta.IdArticulo, articulo.Id }).ToList();

            var resultado = from venta in _context.ArticulosVentas
                            join articulo in _context.ArticulosStocks on venta.IdArticulo equals articulo.Id
                            where articulo.Id == cod
                            select new ArticulosVentas(venta.Id,venta.IdTienda, venta.IdArticulo, venta.PrecioVenta, articulo.SKU, venta.Talla, venta.Cantidad);

            return resultado;
        }
    }
}
