using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendas.Domain.Aggregates;

namespace Tiendas.Domain.Repositories
{
   public interface IArticulosStockRepository
    {
        void Add(ArticulosStock articulo);
        Task<ArticulosStock> GetByIdShein(long id);

        Task<IEnumerable<ArticulosStock>> GetAll();
        Task<ArticulosStock> GetById(long id);
    }
}
