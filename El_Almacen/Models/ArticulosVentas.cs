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
        public long Id { get; private set; }
        public long IdTienda { get; private set; }
        public long IdArticulo { get; private set; }

        public long Cantidad { get; private set; }
        public string Talla { get; private set; }
        public double PrecioVenta { get; private set; }
        public string NombreGestor { get; private set; }

        public ArticulosVentas(long idTienda, long idArticulo, double precioVenta, string nombreGestor, long cantidad, long id, string talla)
        {
            IdTienda = idTienda;
            IdArticulo = idArticulo;
            PrecioVenta = precioVenta;
            NombreGestor = nombreGestor;
            Cantidad = cantidad;
            Id = id;
            Talla = talla;
        }
    }
}
