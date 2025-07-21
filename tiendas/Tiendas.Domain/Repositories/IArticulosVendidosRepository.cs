using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendas.Domain.Aggregates;

namespace Tiendas.Domain.Repositories
{
   public interface IArticulosVendidosRepository
    {
        void Add(ArticulosVendidos articulo);
        Task<ArticulosVendidos> GetById(long id);

        Task<IEnumerable<ArticulosVendidos>> GetAll();
    }
}
