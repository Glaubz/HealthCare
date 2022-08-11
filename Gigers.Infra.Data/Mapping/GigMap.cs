using Gigers.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gigers.Infra.Data.Mapping
{
    public class GigMap : IEntityTypeConfiguration<Gig>
    {
        public void Configure(EntityTypeBuilder<Gig> builder)
        {
            builder.Property(p => p.Titulo).HasColumnType("VARCHAR(250)");
        }
    }
}