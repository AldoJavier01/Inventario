using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiendas.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IArticulosStockRepository ArticulosStockRepository { get; }
        IArticulosVendidosRepository ArticulosVendidosRepository { get; }

        IArticulosVentasRepository ArticulosVentasRepository { get; }

        ITiendaRepository TiendaRepository { get; }
        Task<int> SalvarCambiosAsync(CancellationToken cancellationToken);
    }
}
