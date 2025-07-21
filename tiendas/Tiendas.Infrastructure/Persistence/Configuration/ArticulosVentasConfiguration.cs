using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tiendas.Domain.Aggregates;

namespace Tiendas.Infrastructure.Persistence.Configuration
{
    public class ArticulosVentasConfiguration : IEntityTypeConfiguration<ArticulosVentas>
    {
        public void Configure(EntityTypeBuilder<ArticulosVentas> builder)
        {
            builder.HasKey(t => t.Id);

        }
    }
}
