using Tiendas.Domain.Repositories;
using Tiendas.Infrastructure.Persistence.Repositories;

namespace Fases.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private ArticulosVendidosRepository _articulosVendidosRepository;
    private ArticulosVentasRepository _articulosVentasRepository;
    private TiendasFisicasRepository _tiendasFisicasRepository;
    private ArticulosStockRepository _articulosStockRepository;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IArticulosVendidosRepository ArticulosVendidosRepository =>
        _articulosVendidosRepository ??= new ArticulosVendidosRepository(_context);

    public IArticulosVentasRepository ArticulosVentasRepository =>
        _articulosVentasRepository ??= new ArticulosVentasRepository(_context);

    public IArticulosStockRepository ArticulosStockRepository =>
       _articulosStockRepository ??= new ArticulosStockRepository(_context);

    public ITiendaRepository TiendaRepository =>
        _tiendasFisicasRepository ??= new TiendasFisicasRepository(_context);



    public Task<int> SalvarCambiosAsync(CancellationToken cancellationToken)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }


}
