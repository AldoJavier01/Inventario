using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tiendas.Domain.Aggregates;

namespace Tiendas.Infrastructure.Persistence.Configuration
{
    public class ArticulosStockConfiguration : IEntityTypeConfiguration<ArticulosStock>
    {
        public void Configure(EntityTypeBuilder<ArticulosStock> builder)
        {
            builder.HasKey(t => t.Id);

        }
    }
}
