using Gigers.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gigers.Infra.Data.Mapping
{
    public class GigerMap : IEntityTypeConfiguration<Giger>
    {
        public void Configure(EntityTypeBuilder<Giger> builder)
        {
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(250)");

            builder.Property(p => p.CPF).HasColumnType("CHAR(11)")
                                        .HasMaxLength(11)
                                        .IsFixedLength()
                                        .IsRequired();
        }
    }
}
