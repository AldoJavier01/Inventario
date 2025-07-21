using Tiendas.Domain.Aggregates;

namespace Tiendas.Domain.Repositories
{
    public interface IArticulosVentasRepository
    {
        void Add(ArticulosVentas articulo);
        Task<ArticulosVentas> GetById(long id); 

        Task<IEnumerable<ArticulosVentas>> GetAll();
    }
}
