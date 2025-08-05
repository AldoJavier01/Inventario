using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendas.Domain.Aggregates;

namespace Tiendas.Domain.Repositories
{
   public interface ITiendaRepository
    {
        void Add(TiendasFisicas articulo);
        Task<TiendasFisicas> GetById(long id);

        Task<IEnumerable<TiendasFisicas>> GetAll();
    }
}
