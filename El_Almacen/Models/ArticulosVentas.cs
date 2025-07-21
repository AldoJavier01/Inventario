using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiendas.Domain.Aggregates
{
    public class ArticulosVentas
    {
        private readonly long _id;
        public long Id { get { return _id; } }
        public long IdTienda { get;private set; }
        public long IdArticulo { get;private set; }

        public double PrecioDeCompra {  get;private set; }
        public double PrecioVenta { get;private set; }
        public string NombreGestor {  get;private set; }

        public ArticulosVentas(long idTienda, long idArticulo, double precioVenta, string nombreGestor)
        {
            IdTienda = idTienda;
            IdArticulo = idArticulo;
            PrecioVenta = precioVenta;
            NombreGestor = nombreGestor;
        }
    }
}
