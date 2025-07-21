using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tiendas.Domain.Aggregates;

namespace Tiendas.Infrastructure.Persistence.Configuration
{
    public class TiendasFisicasConfiguration : IEntityTypeConfiguration<TiendasFisicas>
    {
        public void Configure(EntityTypeBuilder<TiendasFisicas> builder)
        {
            builder.HasKey(t => t.Id);

        }
    }

}
