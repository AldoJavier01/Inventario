using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Almacen.Models
{
    public class ArticulosVendidos
    {
        private readonly long _id;
        public long Id { get { return _id; } }
        public long TiendaId { get; private set; }
        public long ArticuloId { get; private set; }
        public double Precio { get; private set; }
        public DateTime Fecha { get; private set; }
        public string NombreGestor { get; private set; }
        public ArticulosVendidos(long tiendaId, long articuloId, double precio, string nombreGestor)
        {
            TiendaId = tiendaId;
            ArticuloId = articuloId;
            Precio = precio;
            Fecha = DateTime.Now;
            NombreGestor = nombreGestor;
        }
    }
}
