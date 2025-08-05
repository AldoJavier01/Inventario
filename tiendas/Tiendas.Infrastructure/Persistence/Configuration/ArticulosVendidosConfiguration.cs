using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tiendas.Domain.Aggregates;

namespace Tiendas.Infrastructure.Persistence.Configuration
{
    public class ArticulosVendidosConfiguration : IEntityTypeConfiguration<ArticulosVendidos>
    {
        public void Configure(EntityTypeBuilder<ArticulosVendidos> builder)
        {
            builder.HasKey(t => t.Id);

        }
    }
}
