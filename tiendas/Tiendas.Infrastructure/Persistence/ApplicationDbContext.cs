using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Tiendas.Domain.Aggregates;

namespace Fases.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<TiendasFisicas> TiendasFisicas => Set<TiendasFisicas>();
    public DbSet<ArticulosVentas> ArticulosVentas => Set<ArticulosVentas>();

    public DbSet<ArticulosVendidos> ArticulosVendidos => Set<ArticulosVendidos>();

    public DbSet<ArticulosStock> ArticulosStocks => Set<ArticulosStock>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
