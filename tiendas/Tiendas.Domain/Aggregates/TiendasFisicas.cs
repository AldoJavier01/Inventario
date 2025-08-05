using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiendas.Domain.Aggregates
{
    public class TiendasFisicas
    {
        private readonly long _id;
        public long Id { get { return _id; } }

        public string Name { get;private set; }

        public string Direccion {  get; private set; }

        public TiendasFisicas(string name, string direccion)
        {
            Name = name;
            Direccion = direccion;
        }

    }
}
